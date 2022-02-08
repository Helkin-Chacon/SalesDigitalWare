using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Sales.BackEnd.Models
{
    public partial class Client
    {
        public Client()
        {
            Invoice = new HashSet<Invoice>();
        }

        public int IdClient { get; set; }
        public string IdentificationNumberClient { get; set; }
        public string NameClient { get; set; }
        public string LastnameClient { get; set; }
        public string NameCompleteClient { get; set; }
        public DateTime RegisterDatevarchar { get; set; }
        public DateTime BirthDatevarchar { get; set; }
   
        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
