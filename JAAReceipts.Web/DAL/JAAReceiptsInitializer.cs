using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using JAAReceipts.Web.Models;

namespace JAAReceipts.Web.DAL
{
    public class JAAReceiptsInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<JAAReceiptsContext>
    {
        protected override void Seed( JAAReceiptsContext context)
        {
            var receiptTypeCategories = new List<ReceiptTypeCategory>
            {
                new ReceiptTypeCategory { ReceiptTypeCategoryID = 1, Description = "Driving Academy"} ,
                new ReceiptTypeCategory { ReceiptTypeCategoryID = 2, Description = "Document Renewal"} ,
                new ReceiptTypeCategory { ReceiptTypeCategoryID = 3, Description = "Asset Desposal"} ,
                new ReceiptTypeCategory { ReceiptTypeCategoryID = 4, Description = "Transport"},
                new ReceiptTypeCategory { ReceiptTypeCategoryID = 5, Description = "Membership"},
                new ReceiptTypeCategory { ReceiptTypeCategoryID = 6, Description = "Invoices"}
            };

            receiptTypeCategories.ForEach(r => context.ReceiptTypeCategory.Add(r));
            context.SaveChanges();

            var receiptType = new List<ReceiptType>
            {
                new ReceiptType { ReceiptTypeID = 1, RecieptTypeCategoryID = 1 , Description = "Driving Lesson"} ,
                new ReceiptType { ReceiptTypeID = 2, RecieptTypeCategoryID = 1 , Description = "Driving Improvement"} ,
                new ReceiptType { ReceiptTypeID = 3, RecieptTypeCategoryID = 2 , Description = "Vehicle Registration"} ,
                new ReceiptType { ReceiptTypeID = 4, RecieptTypeCategoryID = 2 , Description = "Fitness Fee"} ,
                new ReceiptType { ReceiptTypeID = 5, RecieptTypeCategoryID = 2 , Description = "Fitness Renewal"} ,
                new ReceiptType { ReceiptTypeID = 6, RecieptTypeCategoryID = 3 , Description = "Disposal Of Assets"} ,
                new ReceiptType { ReceiptTypeID = 7, RecieptTypeCategoryID = 4 , Description = "Chauffer Service"} ,
                new ReceiptType { ReceiptTypeID = 8, RecieptTypeCategoryID = 4 , Description = "Valet Service"} ,
                new ReceiptType { ReceiptTypeID = 9, RecieptTypeCategoryID = 4 , Description = "Shuttle Service"} ,
                new ReceiptType { ReceiptTypeID = 10, RecieptTypeCategoryID = 4 , Description = "Fleet Service"} ,
                new ReceiptType { ReceiptTypeID = 11, RecieptTypeCategoryID = 4 , Description = "Airport Transportation Service"},
                new ReceiptType { ReceiptTypeID = 12, RecieptTypeCategoryID = 5 , Description = "Black Card"} ,
                new ReceiptType { ReceiptTypeID = 13, RecieptTypeCategoryID = 5 , Description = "Platinum Card"},
                new ReceiptType { ReceiptTypeID = 14, RecieptTypeCategoryID = 5 , Description = "Gold Card"},
                new ReceiptType { ReceiptTypeID = 15, RecieptTypeCategoryID = 5 , Description = "Silver Card"} ,
                new ReceiptType { ReceiptTypeID = 16, RecieptTypeCategoryID = 5 , Description = "Renewal"} ,
                new ReceiptType { ReceiptTypeID = 17, RecieptTypeCategoryID = 6 , Description = "Invoice"}

            };

            receiptType.ForEach(r => context.ReceiptType.Add(r));
            context.SaveChanges();

            var services = new List<Service>
            { 
                new Service {ServiceID = 1 , RecieptTypeID = 1 , Description = "Driving Lesson - Manual - 10 Lessons" , Cost = 0} ,
                new Service {ServiceID = 2 , RecieptTypeID = 1 , Description = "Driving Lesson - Manual - single Lesson" , Cost = 0} ,
                new Service {ServiceID = 3 , RecieptTypeID = 1 , Description = "Driving Lesson - Automatic - 10 Lesson" , Cost = 0} ,
                new Service {ServiceID = 4 , RecieptTypeID = 1 , Description = "Driving Lesson - Automatic - single Lesson" , Cost = 0} ,
                new Service {ServiceID = 5 , RecieptTypeID = 1 , Description = "Driving Lesson - Vehicle Rental" , Cost = 0} ,
                new Service {ServiceID = 6 , RecieptTypeID = 1 , Description = "Driving Lesson - Pick up And Drop off" , Cost = 0} ,
                new Service {ServiceID = 7 , RecieptTypeID = 1 , Description = "Driving Lesson - Driving Academy Registration" , Cost = 0} ,
                new Service {ServiceID = 8 , RecieptTypeID = 1 , Description = "Driving Lesson - Road Code Booklet" , Cost = 0} ,
                new Service {ServiceID = 8 , RecieptTypeID = 2 , Description = "Driver Improvement Program - Individual" , Cost = 0} ,
                new Service {ServiceID = 9 , RecieptTypeID = 2 , Description = "Driver Improvement Program - Company" , Cost = 0} ,
                new Service {ServiceID = 10 , RecieptTypeID = 3 , Description = "Vehicle Registration - 6 Months" , Cost = 0} ,
                new Service {ServiceID = 11 , RecieptTypeID = 3 , Description = "Vehicle Registration - 12 Months" , Cost = 0} ,
                new Service {ServiceID = 10 , RecieptTypeID = 4 , Description = "Fitness Fee Service" , Cost = 0} ,
                new Service {ServiceID = 11 , RecieptTypeID = 5 , Description = "Fitness Renewal Service" , Cost = 0} ,
                new Service {ServiceID = 12 , RecieptTypeID = 6 , Description = "Asset Disposal" , Cost = 0} ,
                new Service {ServiceID = 13 , RecieptTypeID = 7 , Description = "Chauffer Service" , Cost = 0} ,
                new Service {ServiceID = 14 , RecieptTypeID = 8 , Description = "Valet Service" , Cost = 0} ,
                new Service {ServiceID = 15 , RecieptTypeID = 9 , Description = "Shuttle Service" , Cost = 0} ,
                new Service {ServiceID = 16 , RecieptTypeID = 10 , Description = "Fleet Service" , Cost = 0} ,
                new Service {ServiceID = 17 , RecieptTypeID = 11 , Description = "Airport Transportation Service" , Cost = 0} ,
                new Service {ServiceID = 18 , RecieptTypeID = 12 , Description = "Black Card Membership" , Cost = 0} ,
                new Service {ServiceID = 19 , RecieptTypeID = 13 , Description = "Platinum Card Membership" , Cost = 0} ,
                new Service {ServiceID = 20 , RecieptTypeID = 14 , Description = "Gold Card Mebership" , Cost = 0} ,
                new Service {ServiceID = 21 , RecieptTypeID = 15 , Description = "Silver Card Membership" , Cost = 0} ,
                new Service {ServiceID = 22 , RecieptTypeID = 16 , Description = "Membership Renewal" , Cost = 0} ,
                new Service {ServiceID = 23 , RecieptTypeID = 17 , Description = "Invoice" , Cost = 0} ,

            };

            services.ForEach(s => context.Service.Add(s));
            context.SaveChanges();
        }
    }
}
