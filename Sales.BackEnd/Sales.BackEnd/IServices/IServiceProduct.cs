using Sales.BackEnd.Models;
using Sales.BackEnd.Models.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.BackEnd.IServices
{
    public interface IServiceProduct
    {
        Task<List<Product>> GetAllProducts();
        Task<List<Product>> GetProductsMinStock(int mini);
        Task<Product> GetProduct(int id);
        Task<Product> CreateProduct(Product product);
        Task<List<ProdutcsYearVm>> GetTotalProductSell();
    }
}
