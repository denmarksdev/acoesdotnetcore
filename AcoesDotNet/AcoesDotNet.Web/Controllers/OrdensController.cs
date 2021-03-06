﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AcoesDotNet.Model;
using AcoesDotNet.Repository;
using AcoesDotNet.Repository.Base;
using Microsoft.AspNetCore.Mvc;

namespace AcoesDotNet.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdensController : BaseController
    {
        private readonly IOrdemRepository _repo;
        private readonly IGenericRepository<Acao> _acaoRepo;
        private readonly IGenericRepository<Cliente> _clienteRepo;

        public OrdensController(
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
            var ordens = await _repo.GetAllAsync();
            return new ObjectResult(ordens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ordem>> Get(int id)
        {
            var ordem = await _repo.GetByIdAsync(id);
            return new ObjectResult(ordem);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Ordem ordem)
        {
            var mensagemErro = ValidaEntidade(ordem);
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
            Acao acaoPorDataCompra = null;

            if (ordem.DataCompra.HasValue)
            {
                 acaoPorDataCompra = await _acaoRepo.GetByExpression(
                            a => a.CodigoDaAcao == ordem.CodigoAcao && a.DataCotacao.Date <= ordem.DataCompra.Value.Date,
                            campoOrdenacao: nameof(Acao.DataCotacao),
                            desc: true
                        );
            }

            var acaoDataOrdem = await _acaoRepo.GetByExpression(
                a => a.CodigoDaAcao == ordem.CodigoAcao &&   a.DataCotacao.Date <= ordem.DataOrdem.Date,
                campoOrdenacao: nameof(Acao.DataCotacao),
                desc: true
            );

            ordem.EfetuaCalculos(acaoDataOrdem, acaoPorDataCompra, cliente);
        }
    }
}