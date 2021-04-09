using MobiTech.Data.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiTech.DataView
{
    public class SaleVw
    {
        public int Id { get; set; }
        public Int64 IMEI { get; set; }
        public string Mobile { get; set; }
        public string Customer { get; set; }
        public int Price { get; set; }
        public string Email { get; set; }
        public DateTime? DateSale { get; set; }
        public string? Date { get; internal set; }
        public string? Name { get; set; }

        public int LkpMethodId { get; set; }
        public Lokups Method { get; set; }
        public Lokups LkpMethod { get; set; }
        public int? InsertDate { get; internal set; }
        public int? Cost { get; internal set; }

        ////public int MobileNumber { get; set; }
    }
}
