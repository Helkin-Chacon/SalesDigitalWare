using Microsoft.AspNetCore.Mvc;
using Sales.BackEnd.IServices;
using Sales.BackEnd.Models;
using Sales.BackEnd.Models.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly salesCTX ctx;

        private readonly IServiceProduct service;

        public ProductsController(salesCTX _ctx, IServiceProduct _service)
        {
            ctx = _ctx;
            service = _service;
        }

        [HttpGet]
        public async Task<List<Product>> GetAllProducts()
        {
            return await service.GetAllProducts();
        }

        [HttpGet("min/{quanty}")]
        public async Task<List<Product>> GetMinStock(int quanty)
        {
            return await service.GetProductsMinStock(quanty);
        }

        [HttpGet("total")]
        public async Task<List<ProdutcsYearVm>> GetTotal(int quanty)
        {
            return await service.GetTotalProductSell();
        }

        [HttpGet("{id}")]
        public async Task<Product> GetProduct(int id)
        {
            return await service.GetProduct(id);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            var prod = await service.CreateProduct(product);
            if (prod == null)
            {
                return BadRequest();
            }
            return Ok(prod);
        }
    }
}
