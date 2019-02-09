using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcoesDotNet.Model;
using AcoesDotNet.Repository;
using AcoesDotNet.Repository.Base;
using Microsoft.AspNetCore.Mvc;

namespace AcoesDotNet.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdemController : ControllerBase
    {
        private readonly IOrdemRepository _repo;
        private readonly IGenericRepository<Acao> _acaoRepo;
        private readonly IGenericRepository<Cliente> _clienteRepo;

        public OrdemController(
            IOrdemRepository repo, 
            IGenericRepository<Acao> acaoRepo,
            IGenericRepository<Cliente> clienteRepo)
        {
            _repo = repo;
            _acaoRepo = acaoRepo;
            _clienteRepo = clienteRepo;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ordem>>> Get()
        {
            var Ordems = await _repo.GetAllAsync();
            return new ObjectResult(Ordems);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Ordem ordem)
        {
            var mensagemErro = VerificaErro(ordem);
            if (mensagemErro != null)
            {
                return BadRequest(mensagemErro);
            }
            var cliente = await _clienteRepo.GetById(ordem.IdCliente);
            if (cliente == null)
            {
                return BadRequest("idCliente é inválido");
            }
            var acaoExiste = await _acaoRepo.ExistsAsync(a => a.CodigoDaAcao == ordem.CodigoAcao);
            if (!acaoExiste)
            {
                return BadRequest("Código da ação não esta cadastrado");
            }

            await EfetuaCalculosOrdem(ordem, cliente);

            await _repo.InsertAsync(ordem);
            return Ok();
        }

        private async Task EfetuaCalculosOrdem(Ordem ordem, Cliente cliente)
        {
            var acaoDataCompra = await _acaoRepo.GetByExpression(
                            a => a.CodigoDaAcao == ordem.CodigoAcao && a.DataCotacao.Date <= ordem.DataCompra.Date,
                            campoOrdenacao: nameof(Acao.DataCotacao),
                            desc: true
                        );

            var acaoDataOrdem = await _acaoRepo.GetByExpression(
                a => a.CodigoDaAcao == ordem.CodigoAcao &&   a.DataCotacao.Date <= ordem.DataOrdem.Date,
                campoOrdenacao: nameof(Acao.DataCotacao),
                desc: true
            );

            ordem.EfetuaCalculos(acaoDataOrdem,acaoDataCompra,cliente);
        }

        public string VerificaErro(Ordem ordem)
        {
            var erros = ordem.Valida();
            if (erros.Count() == 0) return null;

            return "Erros:\n" + string.Join('\n', erros);
        }
    }
}