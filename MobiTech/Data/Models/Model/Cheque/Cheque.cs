using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;



namespace MobiTech.Data.Models.Model
{
    public class Cheque: AuditModel
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
        //public Lokups ChequeStatus { get; set; }
        public Lokups ChStatus { get; set; }
        

        //  public int MobileNumber { get; set; }


    }
}
