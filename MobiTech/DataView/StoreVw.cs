using MobiTech.Data;
using MobiTech.Data.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiTech.DataView
{
    public class StoreVw
    {
        public int Id { get; set; }
        public Int64 IMEI { get; set; }
        public int? LkpTypeId { get; set; }

        public Lokups LkpType { get; set; }
        public int? LkpColorId { get; set; }

        public Lokups LkpColor { get; set; }
        public int? LkpStorageId { get; set; }

        public Lokups LkpStorage { get; set; }
        public int? LkpRamId { get; set; }

        public Lokups LkpRam { get; set; }

        public string Name { get; set; }
        public int? Price { get; set; }
        public int? PayPrice { get; set; }
        public int? Qty { get; set; }
        //public int? MinPrice { get; set; }
        //public int? MaxPrice { get; set; }
        public int? LkpStatusId { get; set; }

        public Lokups LkpStatus { get; set; }
        public int? LkpActiveId { get; set; }
        public Lokups LkpActive { get; set; }
        public string Type { get; internal set; }
        public string Storage { get; internal set; }
        public string Ram { get; internal set; }
        public string Color { get; internal set; }
        public string Active { get; internal set; }
        public string Status { get; internal set; }
        public string? Date { get; internal set; }
    }
}
