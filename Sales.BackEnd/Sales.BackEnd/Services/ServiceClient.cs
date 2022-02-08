using Microsoft.EntityFrameworkCore;
using Sales.BackEnd.IServices;
using Sales.BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.BackEnd.Services
{
    public class ServiceClient : IServiceClient 
    {
        private readonly salesCTX ctx;
        public ServiceClient(salesCTX _ctx)
        {
            ctx = _ctx;
        }


        public async Task<List<Client>> GetAllClients()
        {
            var List =  await ctx.Client.ToListAsync();
            return List;
        }

        public async Task<Client> GetClientById(int id)
        {
            return await ctx.Client.FindAsync(id);
        }

        public async Task<string> PuTClient(Client client, int id)
        {
            if (client.IdClient == 0)
            {
                client.IdClient = id;
            }
            if (client.IdClient != id)
            {
                return "Peticion no valida";
            }
            if (!await ctx.Client.Where(x => x.IdClient == id).AsNoTracking().AnyAsync())
            {
                return "El Cliente no existe";
            }
            if (await ctx.Client.Where(x => x.IdentificationNumberClient == client.IdentificationNumberClient && x.IdClient != client.IdClient).AnyAsync())
            {
                return "La cedula ya existe";
            }
            try
            {
                ctx.Entry(client).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
                 return "El registro se edito satisfactoriamente";
            }
            
            catch (Exception ex)
            {
                return "Error";
            }
           



        }
        public async Task<string> DeleteClient(int id)
        {
            var client = await ctx.Client.Include(x=>x.Invoice).Where(x=> x.IdClient == id).SingleOrDefaultAsync()  ;
            if(client == null) 
            {
                return "El cliente no existe.";
            }   
            if(client.Invoice.Count > 0)
            {
                return "El cliente tiene facturas asociadas";

            }
            try
            {
                 ctx.Client.Remove(client);
                await ctx.SaveChangesAsync();
                return "Cliente Eliminado.";

            }
            catch (Exception ex)
            {
                return "Error al eliminar";
            }
        }

        
        

        public async Task<List<Client>> GetClients35()
        {
            DateTime initial = new DateTime(2000, 02, 01);
            DateTime endDate = new DateTime(2000, 05, 25);
            List<Invoice> var = await ctx.Invoice.
                Include(x => x.IdClientNavigation).
                Where(x=> x.DateInvoice > initial && x.DateInvoice < endDate ).ToListAsync();
            List<Client> Clients = new List<Client>();
            
            foreach(var invo in var)
            {
         
                if (DateTime.Now.Year - invo.IdClientNavigation.BirthDatevarchar.Year <= 35)
                {
                    Clients.Add(invo.IdClientNavigation);

                }
            }
            return Clients;


        }

        public async Task<string> CreateClient(Client client)
        {
            client.IdClient = 0;
            ctx.Client.Add(client);
            await ctx.SaveChangesAsync();
            return "Creado";
        }
    }
}
