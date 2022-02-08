using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Sales.BackEnd.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            DetailInvoice = new HashSet<DetailInvoice>();
        }

        public int IdInvoice { get; set; }
        public int? IdClient { get; set; }
        public string IdentificationNumberClient { get; set; }
        public DateTime DateInvoice { get; set; }
        public decimal? CostInvoice { get; set; }
        public virtual Client IdClientNavigation { get; set; }
        public virtual ICollection<DetailInvoice> DetailInvoice { get; set; }
    }
}
