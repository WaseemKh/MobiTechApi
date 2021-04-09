
using Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MobiTech.Data.Models.Model.InterNet
{
    public class InterNetNetWork : AuditModel
    {
        public int Id { get; set; }
        public string CustomerName{ get; set; }
        public int LkpCountryId { get; set; }
      public Lokups LkpCountry { get; set; }
        public string Region { get; set; }
        public Int64 PhoneNo { get; set; }
        public Int64 IdNo { get; set; }
        public string Subtype { get; set; }
        public int SubScribePrice { get; set; }
        public int RouterPrice { get; set; }
        public int Debts { get; set; }
        public string BranchName { get; set; }
        public int Totalpayments { get; set; }


    }
}
