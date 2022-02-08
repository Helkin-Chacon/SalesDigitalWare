using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Sales.BackEnd.Models
{
    public partial class Product
    {
        public Product()
        {
            DetailInvoice = new HashSet<DetailInvoice>();
        }

        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public decimal? StockProduct { get; set; }
        public decimal? SaleCostProdutc { get; set; }
        public decimal? PurchaseCostProdutc { get; set; }

        public virtual ICollection<DetailInvoice> DetailInvoice { get; set; }
    }
}
