using Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MobiTech.Data.Models.Model
{
    public class Sale: AuditModel
    {
        public int Id { get; set; }
        public Int64 IMEI { get; set; }
        public string Mobile { get; set; }
        public string Customer { get; set; }
        public int Price { get; set; }
        public string Email { get; set; }
        public DateTime? DateSale { get; set; }


        public int LkpMethodId { get; set; }
     //   public Lokups Method { get; set; }
        public Lokups LkpMethod { get; set; }

        //public int MobileNumber { get; set; }


        public ICollection<Cheque> Customers { get; set; }







    }
}
