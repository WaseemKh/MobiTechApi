using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MobiTech.Data.Models.Model;
using MobiTech.Data.Models.Model.InterNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiTech.Data
{
    public class IdentityDbContext : DbContext
    {

    }
    public class MobiDbContext : IdentityDbContext<SysUsers>
    {
        public MobiDbContext(DbContextOptions<MobiDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        //========= Lookups Tables ====================================
        public DbSet<LkpType> lkpTypes { get; set; }

        public DbSet<Lokups> lokups { get; set; }

        //========= Store ====================================
       public DbSet<Store> Stors { get; set; }

        //==========Customer ========================
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Cheque> cheques { get; set; }

        //===========Authentocation=============
        public DbSet<SysUsers> SysUsers { get; set; }
        //===========InterNetNetwork=============

        public DbSet<InterNetNetWork> InterNetNetWorks { get; set; }

    }
}
