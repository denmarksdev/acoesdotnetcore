using System.Collections.Generic;
using System.Threading.Tasks;
using AcoesDotNet.Model;
using AcoesDotNet.Repository.Base;
using Microsoft.AspNetCore.Mvc;

namespace AcoesDotNet.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
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
        public async Task Post([FromBody] Cliente cliente)
        {
            await repo.InsertAsync(cliente);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Cliente cliente)
        {
            if (id != cliente.Id)
                return BadRequest("Id do cliente inválido");

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