
using Microsoft.AspNetCore.Mvc;
using Sales.BackEnd.IServices;
using Sales.BackEnd.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly salesCTX ctx;

        private readonly IServiceClient service;
        public ClientsController(salesCTX _ctx, IServiceClient _service)
        {
            ctx = _ctx;
            service = _service;
        }
        [HttpGet]
        public async Task<List<Client>> GetAllClients()
        {
            return await service.GetAllClients();
        }
        [HttpPost]
        public async Task<IActionResult> CreateClient(Client client)
        {
            var valid = await service.CreateClient(client);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<string> Delete( int id)
        {
            return await service.DeleteClient(id);
        }

        [HttpPut("{id}")]
        public async Task<string> Update(Client client,int id)
        {
            return await service.PuTClient(client, id);
        }


        [HttpGet("range")]
        public async Task<List<Client>> GetClientsRange()
        {
            return await service.GetClients35();
        }

    }
}
