using Microsoft.AspNetCore.Mvc;
using Sales.BackEnd.IServices;
using Sales.BackEnd.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IServiceInvoice service;
        private readonly salesCTX ctx;

        public InvoiceController(salesCTX _ctx, IServiceInvoice _service)
        {
            ctx = _ctx;
            service = _service;
        }
        [HttpGet]
        public async Task<List<Invoice>> GetAll()
        {
            return await service.GetAll();
        }   
        [HttpPost]
        public async Task<IActionResult> CreateInvoice(Invoice invoice)
        {
            var valid = await service.CreateInvoice(invoice);
            return Ok();
        }
    }
}
