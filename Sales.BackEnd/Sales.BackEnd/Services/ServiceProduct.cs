using Microsoft.EntityFrameworkCore;
using Sales.BackEnd.IServices;
using Sales.BackEnd.Models;
using Sales.BackEnd.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.BackEnd.Services
{
    public class ServiceProduct : IServiceProduct
    {
        private readonly salesCTX ctx;
        public ServiceProduct(salesCTX _ctx)
        {
            ctx = _ctx;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            //if (!await ctx.Product.Where(x => x.IdProduct == x.IdProduct).AnyAsync())
            //{
            //    return BadRequest();  
            //}
            try
            {
                product.IdProduct = 0;
                ctx.Product.Add(product);
                await ctx.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await ctx.Product.ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await ctx.Product.FindAsync(id);

        }

        public async Task<List<Product>> GetProductsMinStock(int min)
        {
            return await ctx.Product.Where(x => x.StockProduct < min).ToListAsync();
        }

        public async Task<List<ProdutcsYearVm>> GetTotalProductSell()
        {
            var products = await ctx.Product.Include(x=> x.DetailInvoice).Where(x=>x.DetailInvoice.Count> 0).AsNoTracking().ToListAsync();
            List<ProdutcsYearVm> listret = new List<ProdutcsYearVm>();
            
            foreach (var prod in products)
            {
                ProdutcsYearVm temp = new ProdutcsYearVm();
                temp.idProduct = prod.IdProduct;
                temp.productName = prod.NameProduct;
               
                foreach (var detail in prod.DetailInvoice)
                {
                    temp.total = temp.total + (double)detail.CostProduct; 
                }
                listret.Add(temp);
            }
            return listret;


        }
    }
}
