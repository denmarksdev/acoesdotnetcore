using System.Collections.Generic;
using System.Threading.Tasks;
using AcoesDotNet.Model;
using AcoesDotNet.Repository.Base;
using Microsoft.AspNetCore.Mvc;

namespace AcoesDotNet.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcoesController : BaseController
    {
        private readonly IGenericRepository<Acao> repo;

        public AcoesController(IGenericRepository<Acao> repo)
        {
            this.repo = repo;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acao>>> Get()
        {
            var acoes = await repo.GetAllAsyc();
            return new ObjectResult(acoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Acao>> Get(int id)
        {
            var Acao = await repo.GetById(id);
            return new ObjectResult(Acao); ;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Acao acao)
        {
            var mensagemErro = ValidaEntidade(acao);
            if (mensagemErro != null)
            {
                return BadRequest(mensagemErro);
            }
            await repo.InsertAsync(acao);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Acao acao)
        {
            var acaoExiste = await repo.ExistsAsync(a => a.Id == id);
            if (id != acao.Id)
                return BadRequest("Código da ação é invalido");

            var mensagemErro = ValidaEntidade(acao);
            if (mensagemErro != null)
            {
                return BadRequest(mensagemErro);
            }

            await repo.UpdateAsync(acao);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await repo.DeleteAsync(id);
        }
    }
}
