using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Sales.BackEnd.Models
{
    public partial class DetailInvoice
    {
        public int IdDetailInvoice { get; set; }
        public int? IdInvoice { get; set; }
        public int? IdProduct { get; set; }
        public string NameProduct { get; set; }
        public decimal? QuantityProduct { get; set; }
        public decimal? CostProduct { get; set; }
        public DateTime? DateSale { get; set; }

        [JsonIgnore]
        public virtual Invoice IdInvoiceNavigation { get; set; }

        [JsonIgnore]
        public virtual Product IdProductNavigation { get; set; }
    }
}
