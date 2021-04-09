using MobiTech.Data.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiTech.DataView
{
    public class ChequeVw
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Sale Customer { get; set; }
        public string Owner { get; set; }
        public int ChequeNo { get; set; }
        public String Bank { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public int ChStatusId { get; set; }
        public Lokups ChequeStatus { get; set; }
        public Lokups ChStatus { get; set; }
        public string? Name { get; set; }
        public string Customers { get; set; }
        public string? CheqDate { get; internal set; }
        public string Status { get; internal set; }
        public long IMEI { get; internal set; }
    }
}
