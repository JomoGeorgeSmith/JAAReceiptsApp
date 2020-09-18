using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using JAAReceipts.WebApp.Models;
using System.Net.Http.Headers;

namespace JAAReceipts.WebApp.Data
{
    public class JAAReceiptsInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<JAAReceiptsContext>
    {

        //public Configuration()
        //{
        //    AutomaticMigrationsEnabled = false;
        //}


        protected override void Seed( JAAReceiptsContext context)
        {
            var receiptTypeCategories = new List<ReceiptTypeCategory>
            {
                new ReceiptTypeCategory { ReceiptTypeCategoryID = 1, Description = "Driving Academy"} ,
                new ReceiptTypeCategory { ReceiptTypeCategoryID = 2, Description = "Motor Vehicle Fitness & Registration - JAA Member "} ,
                new ReceiptTypeCategory { ReceiptTypeCategoryID = 3, Description = "Asset Desposal"} ,
                new ReceiptTypeCategory { ReceiptTypeCategoryID = 4, Description = "Transport"},
                new ReceiptTypeCategory { ReceiptTypeCategoryID = 5, Description = "Membership"},
                new ReceiptTypeCategory { ReceiptTypeCategoryID = 6, Description = "Invoices"} ,
                new ReceiptTypeCategory { ReceiptTypeCategoryID = 37, Description = "Wrecker"},
                new ReceiptTypeCategory { ReceiptTypeCategoryID = 38, Description = "Concierge Services"} ,
                new ReceiptTypeCategory { ReceiptTypeCategoryID = 39, Description = "Motor Vehicle Fitness & Registration - Non JAA Member"},
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
                new ReceiptType { ReceiptTypeID = 17, RecieptTypeCategoryID = 6 , Description = "Invoice"} ,
                new ReceiptType { ReceiptTypeID = 18, RecieptTypeCategoryID = 7 , Description = "Wrecker Service"}

        };

            receiptType.ForEach(r => context.ReceiptType.Add(r));
            context.SaveChanges();

            var services = new List<Service>
        {
            new Service {ServiceID = 1 , RecieptTypeID = 1 , Description = "Learner Driver Standard Manual  10 Lessons" , Cost = 26100.00m} ,
            new Service {ServiceID = 2 , RecieptTypeID = 1 , Description = "Learner Driver Standard  Manual Single Lesson" , Cost = 2500.00m} ,
            new Service {ServiceID = 3 , RecieptTypeID = 1 , Description = "Learner Driver Standard Automatic 10 Lesson" , Cost = 22500.00m} ,
            new Service {ServiceID = 4 , RecieptTypeID = 1 , Description = "Learner Driver Standard Automatic Single Lesson" , Cost = 2950.00m} ,
            new Service {ServiceID = 5 , RecieptTypeID = 1 , Description = "Learner Driver Standard Vehicle Rental For Exam" , Cost = 5000.00m} ,
            new Service {ServiceID = 6 , RecieptTypeID = 1 , Description = "Learner Driver Standard Pick up And Drop off One Way" , Cost = 1500.00m} ,
            new Service {ServiceID = 7 , RecieptTypeID = 1 , Description = "Learner Driver Standard Registration Fee" , Cost = 500.00m} ,
            new Service {ServiceID = 8 , RecieptTypeID = 1 , Description = "Road Code Booklet" , Cost = 500.00m} ,
            new Service {ServiceID = 9 , RecieptTypeID = 1 , Description = "Driver Improvement Program - Individual" , Cost = 11650.00m} ,
            new Service {ServiceID = 10 , RecieptTypeID = 1 , Description = "Driver Improvement Program - Company" , Cost = 17475.00m} ,
            new Service {ServiceID = 11 , RecieptTypeID = 2 , Description = "Motor Vehicle Fitness Renewal" , Cost = 4500.00m} ,
            new Service {ServiceID = 12 , RecieptTypeID = 2 , Description = "Motor Vehicle Registration Certificate Renewal - 6 months, not exceeding 1199cc" , Cost = 4620.00m} ,
            new Service {ServiceID = 13 , RecieptTypeID = 2 , Description = "Motor Vehicle Registration Certificate Renewal - 1 year, not exceeding 1199cc" , Cost = 9240.00m} ,
            new Service {ServiceID = 14 , RecieptTypeID = 2 , Description = "Motor Vehicle Registration Certificate Renewal - 6 months, 1199cc – 2999cc" , Cost = 6300.00m},
            new Service {ServiceID = 15 , RecieptTypeID = 3 , Description = "Asset Disposal" , Cost = 0m},
            new Service {ServiceID = 16 , RecieptTypeID = 38 , Description = "Chauffer Service" , Cost = 6990.00m},
            new Service {ServiceID = 17 , RecieptTypeID = 38 , Description = "Replacement Driver" , Cost = 6990.00m},
            new Service {ServiceID = 18 , RecieptTypeID = 38 , Description = "White Glove Service" , Cost = 139.80m},
            new Service {ServiceID = 19 , RecieptTypeID = 4 , Description = "Shuttle Service" , Cost = 4000.00m},
            new Service {ServiceID = 20 , RecieptTypeID = 38 , Description = "Airport Transportation Service" , Cost = 4000.00m},
            new Service {ServiceID = 21 , RecieptTypeID = 5 , Description = "Black Card Membership" , Cost = 12500.00m},
            new Service {ServiceID = 22 , RecieptTypeID = 5 , Description = "Platinum Card Membership" , Cost = 8500.00m},
            new Service {ServiceID = 23 , RecieptTypeID = 5 , Description = "Gold Card Membership" , Cost = 6000.00m},
            new Service {ServiceID = 24 , RecieptTypeID = 5 , Description = "Silver Card Membership" , Cost = 2950.00m},
            new Service {ServiceID = 25 , RecieptTypeID = 5 , Description = "Membership Renewal" , Cost = 0m },
            new Service {ServiceID = 26 , RecieptTypeID = 6 , Description = "Invoice" , Cost = 0m },
            new Service {ServiceID = 158 , RecieptTypeID = 37 , Description = "Wrecker Service" , Cost = 4000m },
            new Service {ServiceID = 160 , RecieptTypeID = 5 , Description = "Student Membership" , Cost = 4250.00m },
            new Service {ServiceID = 161 , RecieptTypeID = 1 , Description = "Driver Improvement - Driver Assessment" , Cost = 5825.00m },
            new Service {ServiceID = 162 , RecieptTypeID = 1 , Description = "Learner Driver Executive Registration fee" , Cost = 500.00m },
            new Service {ServiceID = 164 , RecieptTypeID = 1 , Description = "Learner Driver Executive Pick Up and Drop Off" , Cost = 500.00m },
            new Service {ServiceID = 165 , RecieptTypeID = 1 , Description = "Learner Driver Executive Automatic/Manual" , Cost = 3262.00m },
            new Service {ServiceID = 166 , RecieptTypeID = 4 , Description = "Towing Service" , Cost = 4000m },
            new Service {ServiceID = 167 , RecieptTypeID = 4 , Description = "Trucking Service" , Cost = 4000m },
            new Service {ServiceID = 175 , RecieptTypeID = 2 , Description = "Motor Vehicle Registration Certificate Renewal - 1 year, 1199cc – 2999cc" , Cost = 12600.00m },
            new Service {ServiceID = 176 , RecieptTypeID = 2 , Description = "Motor Vehicle Registration Certificate Renewal - 6 month, 3000cc – 3999cc" , Cost = 14400.00m },
            new Service {ServiceID = 178 , RecieptTypeID = 2 , Description = "Motor Vehicle Registration Certificate Renewal - 1 year, 3000cc – 3999cc" , Cost = 28800.00m },
            new Service {ServiceID = 179 , RecieptTypeID = 39 , Description = "Motor Vehicle Fitness Renewal" , Cost = 4500.00m },
            new Service {ServiceID = 180 , RecieptTypeID = 39 , Description = "Motor Vehicle Registration Certificate Renewal - 1 year, not exceeding 1199cc" , Cost = 12240.00m },
            new Service {ServiceID = 181 , RecieptTypeID = 39 , Description = "Motor Vehicle Registration Certificate Renewal - 6 months, not exceeding 1199cc" , Cost = 7620.00m },
            new Service {ServiceID = 182 , RecieptTypeID = 39 , Description = "Motor Vehicle Registration Certificate Renewal - 1 year, 1199cc – 2999cc" , Cost = 15600.00m },
            new Service {ServiceID = 183 , RecieptTypeID = 39 , Description = "Motor Vehicle Registration Certificate Renewal - 6 months, 1199cc – 2999cc" , Cost = 9300.00m },
            new Service {ServiceID = 184 , RecieptTypeID = 39 , Description = "Motor Vehicle Registration Certificate Renewal - 6 month, 3000cc – 3999cc" , Cost = 17400.00m },
            new Service {ServiceID = 186 , RecieptTypeID = 39 , Description = "Motor Vehicle Registration Certificate Renewal - 1 year, 3000cc – 3999cc" , Cost = 31800.00m },
            new Service {ServiceID = 187 , RecieptTypeID = 38 , Description = "Fitness Valet" , Cost = 2912.50m },
            new Service {ServiceID = 188 , RecieptTypeID = 38 , Description = "Normal Valet" , Cost = 2912.50m },
            new Service {ServiceID = 189 , RecieptTypeID = 40 , Description = "Fleet Management Service" , Cost = 2912.50m },
            new Service {ServiceID = 191 , RecieptTypeID = 40 , Description = "JAA Advance" , Cost = 2912.50m },



        };

            services.ForEach(s => context.Service.Add(s));
            context.SaveChanges();

            var paymentTypes = new List<PaymentType>
            {
                new PaymentType {PaymentTypeID = 1 , Description = "Cash"},
                new PaymentType {PaymentTypeID = 2 , Description = "Credit Card Walk In"},
                new PaymentType {PaymentTypeID = 3 , Description = "Credit Card Internet"},
                new PaymentType {PaymentTypeID = 4 , Description = "Debit Card"},
                new PaymentType {PaymentTypeID = 5 , Description = "JNBS - Direct Deposit"},
                new PaymentType {PaymentTypeID = 6 , Description = "BNS - Direct Deposit"},
                new PaymentType {PaymentTypeID = 7 , Description = "Direct Deposit JN Cheque"},
                new PaymentType {PaymentTypeID = 8 , Description = "Cheque"},
                new PaymentType {PaymentTypeID = 9 , Description = "JNBS - Bearer"},
                new PaymentType {PaymentTypeID = 10 , Description = "JNBS - Savings"},
                new PaymentType {PaymentTypeID = 11 , Description = "JNBS - US Dollar"},
                new PaymentType {PaymentTypeID = 12 , Description = "NCB - Direct Deposit"},
                new PaymentType {PaymentTypeID = 13 , Description = "NCB - Credit Card"},
            };

            paymentTypes.ForEach(p => context.PaymentType.Add(p));
            context.SaveChanges();

            var documentType = new List<DocumentType>
            {
                new DocumentType{DocumentTypeID = 1  , Description = "CS"},
                new DocumentType{DocumentTypeID = 2  , Description = "DP"},

            };

            documentType.ForEach(d => context.DocumentType.Add(d));
            context.SaveChanges();

            var bankCode = new List<BankCode>
            {
                new BankCode{BankCodeID = 1 , PaymentTypeID = 5 , BankCodeNumber = 130045},
                new BankCode{BankCodeID = 2 , PaymentTypeID = 9 , BankCodeNumber = 130030},
                new BankCode{BankCodeID = 3 , PaymentTypeID = 10 , BankCodeNumber = 130000},
                new BankCode{BankCodeID = 4 , PaymentTypeID = 11 , BankCodeNumber = 131030},
                new BankCode{BankCodeID = 5 , PaymentTypeID = 6 , BankCodeNumber = 131050},
                new BankCode{BankCodeID = 6 , PaymentTypeID = 12 , BankCodeNumber = 131070},
                new BankCode{BankCodeID = 7 , PaymentTypeID = 13 , BankCodeNumber = 188090},
            };
            bankCode.ForEach(b => context.BankCode.Add(b));
            context.SaveChanges();

            var incomeAccount = new List<IncomeAccountListing>
            {
                new IncomeAccountListing{IncomeAccountListingID = 3 , ServiceID = 23 , IncomeAccountNumber = 420061 , CooperateClientID = null},
                new IncomeAccountListing{IncomeAccountListingID = 4 , ServiceID = 24 , IncomeAccountNumber = 420062 , CooperateClientID = null},
                new IncomeAccountListing{IncomeAccountListingID = 5 , ServiceID = 21 , IncomeAccountNumber = 420065 , CooperateClientID = null},
                new IncomeAccountListing{IncomeAccountListingID = 6 , ServiceID = 15 , IncomeAccountNumber = 420130 , CooperateClientID = null},
                new IncomeAccountListing{IncomeAccountListingID = 7 , ServiceID = 188 , IncomeAccountNumber = 420310 , CooperateClientID = null},
                new IncomeAccountListing{IncomeAccountListingID = 9 , ServiceID = 187 , IncomeAccountNumber = 420310 , CooperateClientID = null},
                new IncomeAccountListing{IncomeAccountListingID = 10 , ServiceID = 17 , IncomeAccountNumber = 420315 , CooperateClientID = null},
                new IncomeAccountListing{IncomeAccountListingID = 11 , ServiceID = 16 , IncomeAccountNumber = 420316 , CooperateClientID = null},
                new IncomeAccountListing{IncomeAccountListingID = 12 , ServiceID = 18 , IncomeAccountNumber = 420320 , CooperateClientID = null},
                new IncomeAccountListing{IncomeAccountListingID = 13 , ServiceID = 158 , IncomeAccountNumber = 424150 , CooperateClientID = null},
                new IncomeAccountListing{IncomeAccountListingID = 14 , ServiceID = 189 , IncomeAccountNumber = 424201 , CooperateClientID = 1},
                new IncomeAccountListing{IncomeAccountListingID = 15 , ServiceID = 189 , IncomeAccountNumber = 424202 , CooperateClientID = 2},
                new IncomeAccountListing{IncomeAccountListingID = 16 , ServiceID = 189 , IncomeAccountNumber = 424203 , CooperateClientID = 3},
                new IncomeAccountListing{IncomeAccountListingID = 17 , ServiceID = 189 , IncomeAccountNumber = 424204 , CooperateClientID = 4},
                new IncomeAccountListing{IncomeAccountListingID = 18 , ServiceID = 189 , IncomeAccountNumber = 424205 , CooperateClientID = 5},
                new IncomeAccountListing{IncomeAccountListingID = 19 , ServiceID = 189 , IncomeAccountNumber = 424206 , CooperateClientID = 6},
                new IncomeAccountListing{IncomeAccountListingID = 20 , ServiceID = 161 , IncomeAccountNumber = 424300, CooperateClientID = null},
                new IncomeAccountListing{IncomeAccountListingID = 22 , ServiceID = 9 , IncomeAccountNumber = 424300, CooperateClientID = null},
                new IncomeAccountListing{IncomeAccountListingID = 23 , ServiceID = 10 , IncomeAccountNumber = 424300, CooperateClientID = null},
                new IncomeAccountListing{IncomeAccountListingID = 24 , ServiceID = 8 , IncomeAccountNumber = 424300, CooperateClientID = null},
                new IncomeAccountListing{IncomeAccountListingID = 25 , ServiceID = 1 , IncomeAccountNumber = 424310, CooperateClientID = null},
                new IncomeAccountListing{IncomeAccountListingID = 26 , ServiceID = 2 , IncomeAccountNumber = 424310, CooperateClientID = null},
                new IncomeAccountListing{IncomeAccountListingID = 27 , ServiceID = 3 , IncomeAccountNumber = 424310, CooperateClientID = null},
                new IncomeAccountListing{IncomeAccountListingID = 28 , ServiceID = 4 , IncomeAccountNumber = 424310, CooperateClientID = null},
                new IncomeAccountListing{IncomeAccountListingID = 29 , ServiceID = 5 , IncomeAccountNumber = 424310, CooperateClientID = null},
                new IncomeAccountListing{IncomeAccountListingID = 30 , ServiceID = 6 , IncomeAccountNumber = 424310, CooperateClientID = null},
                new IncomeAccountListing{IncomeAccountListingID = 31 , ServiceID = 7 , IncomeAccountNumber = 424310, CooperateClientID = null},
                new IncomeAccountListing{IncomeAccountListingID = 31 , ServiceID = 7 , IncomeAccountNumber = 424310, CooperateClientID = null},
                new IncomeAccountListing{IncomeAccountListingID = 32 , ServiceID = 165 , IncomeAccountNumber = 424311, CooperateClientID = null},
                new IncomeAccountListing{IncomeAccountListingID = 33 , ServiceID = 164 , IncomeAccountNumber = 424311, CooperateClientID = null},
                new IncomeAccountListing{IncomeAccountListingID = 34 , ServiceID = 162 , IncomeAccountNumber = 424311, CooperateClientID = null},
                new IncomeAccountListing{IncomeAccountListingID = 35 , ServiceID = 19 , IncomeAccountNumber = 450010, CooperateClientID = null},
                new IncomeAccountListing{IncomeAccountListingID = 36 , ServiceID = 167 , IncomeAccountNumber = 450030, CooperateClientID = null},


            };
            incomeAccount.ForEach(i => context.IncomeAccountListing.Add(i));
            context.SaveChanges();
        }
    }
}
