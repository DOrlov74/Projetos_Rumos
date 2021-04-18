using Microsoft.EntityFrameworkCore;
using StorePOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoDados
{
    class AcessoDbContext:DbContext
    {
        //public AcessoDbContext(DbContextOptions<AcessoDbContext> options):base(options)
        //{

        //}
        public DbSet<tblStore> Stores { get; set; }
        public DbSet<tblPos> MyPos { get; set; }
        public DbSet<tblUser> tblUser { get; set; }
        public DbSet<tblFamily> tblFamily { get; set; }
        public DbSet<tblPayment> tblPayments { get; set; }
        public DbSet<tblPaymentType> tblPaymentTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder db)
        {
            db.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = ProjetoDO_DB; Integrated Security = True");
        }
    }
}
