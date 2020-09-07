using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JAAReceipts.Web.Models;
//using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace JAAReceipts.Web.Data
{
    public class JAAReceiptsWebContext : DbContext
    {
        public JAAReceiptsWebContext(DbContextOptions<JAAReceiptsWebContext> options)
            : base(options)
        {
        }

        //public JAAReceiptsWebContext() : base("JAAReceiptsWebContext")
        //{
        //}

        public DbSet<Receipt> Receipt { get; set; }

        public DbSet<ReceiptItem> ReceiptItem { get; set; }

        public DbSet<PaymentType> PaymentType { get; set; }

        public DbSet<DocumentType> DocumentType { get; set; }

        public DbSet<Service> Service { get; set; }

        public DbSet<ReceiptType> ReceiptType { get; set; }

        public DbSet<ReceiptTypeCategory> ReceiptTypeCategory { get; set; }

    }
}
