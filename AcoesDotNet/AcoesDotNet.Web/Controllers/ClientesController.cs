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
    public class ClientesController : BaseController
    {
        private readonly IGenericRepository<Cliente> repo;

        public ClientesController(IGenericRepository<Cliente> repo)
        {
            this.repo = repo;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> Get()
        {
            var clientes = await repo.GetAllAsyc();
            return new ObjectResult( clientes);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            var cliente = await repo.GetById(id);
            return new ObjectResult(cliente); ;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            var mensagemErro = ValidaEntidade(cliente);
            if (mensagemErro != null)
            {
                return BadRequest(mensagemErro);
            }
            await repo.InsertAsync(cliente);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Cliente cliente)
        {
            if (id != cliente.Id)
                return BadRequest("Id do cliente inválido");

            var mensagemErro = ValidaEntidade(cliente);
            if (mensagemErro != null)
            {
                return BadRequest(mensagemErro);
            }

            await repo.UpdateAsync(cliente);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await repo.DeleteAsync(id);
        }
    }
}