using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using JAAReceipts.WebApp.Models;

namespace JAAReceipts.WebApp.Data
{
    public class JAAReceiptsContext : DbContext
    {

        public JAAReceiptsContext() : base("JAAReceiptsContext")
        {
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    var testEntityConf = modelBuilder.Entity<TestEntity>();
        //    testEntityConf.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        //}

        public DbSet<Receipt> Receipt { get; set;  }

        public DbSet<ReceiptItem> ReceiptItem { get; set; }

        public DbSet<PaymentType> PaymentType { get; set; }

        public DbSet<DocumentType> DocumentType { get; set; }

        public DbSet<Service> Service { get; set; }

        public DbSet<ReceiptType> ReceiptType { get; set; }

        public DbSet<ReceiptTypeCategory> ReceiptTypeCategory { get; set; }

        public DbSet<BankCode> BankCode { get; set; }

        public DbSet<CooperateClients> CooperateClients { get; set; }

        public DbSet<IncomeAccountListing> IncomeAccountListing { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
