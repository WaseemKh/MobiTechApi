using MobiTech.Data.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiTech.DataView
{
    public class InterNetNetworkVw
    {
        public int Id { get; set; }
        public String CustomerName { get; set; }
        public int CountryId { get; set; }
        public Lokups Country { get; set; }
        public String Region { get; set; }
        public Int64 PhoneNo { get; set; }
        public Int64 IdNo { get; set; }
        public string Subtype { get; set; }
    
        public int SubScribePrice { get; set; }
        public int RouterPrice { get; set; }
        public int Debts { get; set; }
        public string CountryName { get; internal set; }
        public string BranchName { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
