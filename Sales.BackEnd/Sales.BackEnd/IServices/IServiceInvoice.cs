using Sales.BackEnd.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.BackEnd.IServices
{
    public interface IServiceInvoice
    {
        Task<string> CreateInvoice(Invoice invoice);
        Task<List<Invoice>> GetAll();

    }
}
