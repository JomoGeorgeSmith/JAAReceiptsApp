using JAAReceipts.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JAAReceipts.DataLayer.Data
{
    public class JAAReceiptsContext : DbContext
    {
        public DbSet<Receipt> Receipt { get; set;  }

        public DbSet<ReceiptItem> ReceiptItem { get; set; }

        public DbSet<PaymentType> PaymentType { get; set; }

        public DbSet<DocumentType> DocumentType { get; set; }

        public DbSet<Service> Service { get; set; }

        public DbSet<ReceiptType> ReceiptType { get; set; }

        public DbSet<ReceiptTypeCategory> ReceiptTypeCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; " +
                "Initial Catalog = JAAReceipts; Integrated Security = True; " +
                "Connect Timeout = 30; Encrypt = False; " +
                "TrustServerCertificate = False; " +
                "ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }
    }
}
