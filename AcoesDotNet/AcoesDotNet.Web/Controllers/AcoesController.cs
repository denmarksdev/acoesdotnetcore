using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcoesDotNet.Model;
using AcoesDotNet.Repository.Base;
using Microsoft.AspNetCore.Mvc;

namespace AcoesDotNet.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcoesController : ControllerBase
    {
        private readonly IGenericRepository<Acao> repo;

        public AcoesController(IGenericRepository<Acao> repo)
        {
            this.repo = repo;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acao>>> Get()
        {
            var Acaos = await repo.GetAllAsyc();
            return new ObjectResult(Acaos);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Acao>> Get(int id)
        {
            var Acao = await repo.GetById(id);
            return new ObjectResult(Acao); ;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Acao Acao)
        {
            var mensagemErro = VerificaErro(Acao);
            if (mensagemErro != null)
            {
                return BadRequest(mensagemErro);
            }
            await repo.InsertAsync(Acao);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Acao Acao)
        {
            if (id != Acao.Id)
                return BadRequest("Id do Acao inválido");

            var mensagemErro = VerificaErro(Acao);
            if (mensagemErro != null)
            {
                return BadRequest(mensagemErro);
            }

            await repo.UpdateAsync(Acao);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await repo.DeleteAsync(id);
        }

        public string VerificaErro(Acao Acao)
        {
            var erros = Acao.Valida();
            if (erros.Count() == 0) return null;

            return "Erros:\n" + string.Join('\n', erros);
        }
    }
}
