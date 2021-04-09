using Domain.Model;
using Domain.Model.Lookups;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Store
{
    public class Store : AuditModel
    {
        public int Id { get; set; }
        public int IMEI { get; set; }
        public Lokups LkpType { get; set; }
        public int TypeNo { get; set; }
        public Lokups LkpColor { get; set; }
        public int ColorNo { get; set; }
        public Lokups LkpStorage { get; set; }
        public int StorgeNo { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public Lokups LkpStatus { get; set; }
        public int StatusNo { get; set; }
        public Lokups LkpActive { get; set; }
        public int ActiveNo { get; set; }
        public Lokups Ram { get; set; }
        public int RamNo { get; set; }

    }
}
