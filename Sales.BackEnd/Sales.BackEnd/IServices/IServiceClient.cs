using Sales.BackEnd.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.BackEnd.IServices
{
    public interface IServiceClient

    {
        Task<List<Client>> GetAllClients();
        Task<Client> GetClientById(int id);
        Task<string> PuTClient(Client client, int id);
        Task<string> CreateClient(Client client);
        Task<string> DeleteClient(int id);
        Task<List<Client>> GetClients35();

    }
}
