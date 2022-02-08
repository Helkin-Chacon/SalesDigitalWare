using Microsoft.EntityFrameworkCore;
using Sales.BackEnd.IServices;
using Sales.BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.BackEnd.Services
{
    public class ServiceInvoice : IServiceInvoice
    {
        private readonly salesCTX ctx;
        public ServiceInvoice(salesCTX _ctx)
        {
            ctx = _ctx;
        }
        public async Task<string> CreateInvoice(Invoice invoice)
        {
            if (invoice.DetailInvoice == null || invoice.DetailInvoice.Count == 0)
            {
                return null;
            }
            try
            {


                ICollection<DetailInvoice> var = invoice.DetailInvoice;
                invoice.DetailInvoice = null;
                invoice.DateInvoice = DateTime.Now;
                ctx.Invoice.Add(invoice);
                await ctx.SaveChangesAsync();

                foreach (var item in var)
                {
                    item.IdInvoice = invoice.IdInvoice;
                    ctx.DetailInvoice.Add(item);
                    item.DateSale = DateTime.Now;

                }

                await ctx.SaveChangesAsync();
                return "Registro Satisfactorio";
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        public async Task<List<Invoice>> GetAll()
        {
            return await ctx.Invoice.Include(x => x.DetailInvoice).Include(x=>x.IdClientNavigation).ToListAsync();
        }
    }
}
