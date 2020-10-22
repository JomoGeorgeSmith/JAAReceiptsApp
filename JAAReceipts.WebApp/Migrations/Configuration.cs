using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using JAAReceipts.WebApp.Models;
using JAAReceipts.WebApp.Data;
using System.Collections.Generic;


namespace JAAReceipts.WebApp.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<JAAReceipts.WebApp.Data.JAAReceiptsContext>

    {
        public Configuration()
        {
            //set to true when updating database, i can skip the migration step. 
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = true; 
        }


        //This one is being called

        protected override void Seed(JAAReceiptsContext context)
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
                    new ReceiptTypeCategory { ReceiptTypeCategoryID = 40, Description = "Cooperate Sevices"}
                };

            //using (var transaction = context.Database.BeginTransaction())
            //{

                receiptTypeCategories.ForEach(r => context.ReceiptTypeCategory.AddOrUpdate(r));
                //context.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT dbo.ReceiptTypeCategory ON;");
                context.SaveChanges();
            //context.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT dbo.ReceiptTypeCategory OFF;");
            //transaction.Commit();
            //}

            var currencies = new List<Currency>
            {
                new Currency{CurrencyID = 1 , Description = "Jamaican Dollars" , CurrencyCode = "JMD" } ,
                new Currency{CurrencyID = 2 , Description = "United States Dollars" , CurrencyCode = "USD" }
            };

            //using (var transaction = context.Database.BeginTransaction())
            //{
            currencies.ForEach(i => context.Currency.AddOrUpdate(i));
            //context.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT dbo.IncomeAccountListing ON;");
            context.SaveChanges();
            //context.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT dbo.IncomeAccountListing ON;");
            //transaction.Commit();

            //}

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

            //using (var transaction = context.Database.BeginTransaction())
            //{

                receiptType.ForEach(r => context.ReceiptType.AddOrUpdate(r));
                //context.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT dbo.ReceiptType ON;");
                context.SaveChanges();
                //context.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT dbo.ReceiptType OFF;");
                //transaction.Commit();
            //}

            var services = new List<Service>
            {
                new Service {ServiceID = 1 , RecieptTypeID = 1 , Description = "Learner Driver Standard Manual  10 Lessons" , Cost = 26100.00m , CurrencyID = 1 , GCT = false} ,
                new Service {ServiceID = 2 , RecieptTypeID = 1 , Description = "Learner Driver Standard  Manual Single Lesson" , Cost = 2500.00m , CurrencyID = 1, GCT = false} ,
                new Service {ServiceID = 3 , RecieptTypeID = 1 , Description = "Learner Driver Standard Automatic 10 Lesson" , Cost = 22500.00m , CurrencyID = 1, GCT = false} ,
                new Service {ServiceID = 4 , RecieptTypeID = 1 , Description = "Learner Driver Standard Automatic Single Lesson" , Cost = 2950.00m , CurrencyID = 1, GCT = false} ,
                new Service {ServiceID = 5 , RecieptTypeID = 1 , Description = "Learner Driver Standard Vehicle Rental For Exam" , Cost = 5000.00m , CurrencyID = 1, GCT = false} ,
                new Service {ServiceID = 6 , RecieptTypeID = 1 , Description = "Learner Driver Standard Pick up And Drop off One Way" , Cost = 1500.00m , CurrencyID = 1, GCT = false} ,
                new Service {ServiceID = 7 , RecieptTypeID = 1 , Description = "Learner Driver Standard Registration Fee" , Cost = 500.00m , CurrencyID = 1, GCT = false} ,
                new Service {ServiceID = 8 , RecieptTypeID = 1 , Description = "Road Code Booklet" , Cost = 500.00m , CurrencyID = 1, GCT = false} ,
                new Service {ServiceID = 9 , RecieptTypeID = 1 , Description = "Driver Improvement Program - Individual" , Cost = 11650.00m , CurrencyID = 1, GCT = false} ,
                new Service {ServiceID = 10 , RecieptTypeID = 1 , Description = "Driver Improvement Program - Company" , Cost = 17475.00m , CurrencyID = 1, GCT = false} ,
                new Service {ServiceID = 11 , RecieptTypeID = 2 , Description = "Motor Vehicle Fitness Renewal" , Cost = 4500.00m , CurrencyID = 1, GCT = false} ,
                new Service {ServiceID = 12 , RecieptTypeID = 2 , Description = "Motor Vehicle Registration Certificate Renewal - 6 months, not exceeding 1199cc" , Cost = 4620.00m , CurrencyID = 1, GCT = false} ,
                new Service {ServiceID = 13 , RecieptTypeID = 2 , Description = "Motor Vehicle Registration Certificate Renewal - 1 year, not exceeding 1199cc" , Cost = 9240.00m , CurrencyID = 1, GCT = false} ,
                new Service {ServiceID = 14 , RecieptTypeID = 2 , Description = "Motor Vehicle Registration Certificate Renewal - 6 months, 1199cc – 2999cc" , Cost = 6300.00m , CurrencyID = 1, GCT = false},
                new Service {ServiceID = 15 , RecieptTypeID = 3 , Description = "Asset Disposal" , Cost = 0m , CurrencyID = 1, GCT = false},
                new Service {ServiceID = 16 , RecieptTypeID = 38 , Description = "Chauffer Service" , Cost = 6990.00m , CurrencyID = 1, GCT = false},
                new Service {ServiceID = 17 , RecieptTypeID = 38 , Description = "Replacement Driver" , Cost = 6990.00m , CurrencyID = 1, GCT = false},
                new Service {ServiceID = 18 , RecieptTypeID = 38 , Description = "White Glove Service" , Cost = 139.80m , CurrencyID = 2, GCT = false},
                new Service {ServiceID = 19 , RecieptTypeID = 4 , Description = "Shuttle Service" , Cost = 4000.00m , CurrencyID = 1, GCT = false},
                new Service {ServiceID = 20 , RecieptTypeID = 38 , Description = "Airport Transportation Service" , Cost = 4000.00m , CurrencyID = 1},
                new Service {ServiceID = 21 , RecieptTypeID = 5 , Description = "Black Card Membership" , Cost = 12500.00m , CurrencyID = 1 , GCT = true},
                new Service {ServiceID = 22 , RecieptTypeID = 5 , Description = "Platinum Card Membership" , Cost = 8500.00m , CurrencyID = 1 , GCT = true} ,
                new Service {ServiceID = 23 , RecieptTypeID = 5 , Description = "Gold Card Membership" , Cost = 6000.00m , CurrencyID = 1, GCT = true},
                new Service {ServiceID = 24 , RecieptTypeID = 5 , Description = "Silver Card Membership" , Cost = 2950.00m , CurrencyID = 1, GCT = true},
                new Service {ServiceID = 25 , RecieptTypeID = 5 , Description = "Membership Renewal" , Cost = 0m , CurrencyID = 1, GCT = true},
                new Service {ServiceID = 26 , RecieptTypeID = 6 , Description = "Invoice" , Cost = 0m , CurrencyID = 1},
                new Service {ServiceID = 158 , RecieptTypeID = 37 , Description = "Wrecker Service" , Cost = 4000m , CurrencyID = 1},
                new Service {ServiceID = 160 , RecieptTypeID = 5 , Description = "Student Membership" , Cost = 4250.00m , CurrencyID = 1, GCT = true},
                new Service {ServiceID = 161 , RecieptTypeID = 1 , Description = "Driver Improvement - Driver Assessment" , Cost = 5825.00m , CurrencyID = 1, GCT = false},
                new Service {ServiceID = 162 , RecieptTypeID = 1 , Description = "Learner Driver Executive Registration fee" , Cost = 500.00m , CurrencyID = 1, GCT = false},
                new Service {ServiceID = 164 , RecieptTypeID = 1 , Description = "Learner Driver Executive Pick Up and Drop Off" , Cost = 500.00m , CurrencyID = 1, GCT = false},
                new Service {ServiceID = 165 , RecieptTypeID = 1 , Description = "Learner Driver Executive Automatic/Manual" , Cost = 3262.00m , CurrencyID = 1, GCT = false},
                new Service {ServiceID = 166 , RecieptTypeID = 5 , Description = "Towing Service" , Cost = 4000m , CurrencyID = 1 , GCT = true},
                new Service {ServiceID = 167 , RecieptTypeID = 4 , Description = "Trucking Service" , Cost = 4000m , CurrencyID = 1, GCT = false},
                new Service {ServiceID = 175 , RecieptTypeID = 2 , Description = "Motor Vehicle Registration Certificate Renewal - 1 year, 1199cc – 2999cc" , Cost = 12600.00m , CurrencyID = 1, GCT = false},
                new Service {ServiceID = 176 , RecieptTypeID = 2 , Description = "Motor Vehicle Registration Certificate Renewal - 6 month, 3000cc – 3999cc" , Cost = 14400.00m , CurrencyID = 1, GCT = false},
                new Service {ServiceID = 178 , RecieptTypeID = 2 , Description = "Motor Vehicle Registration Certificate Renewal - 1 year, 3000cc – 3999cc" , Cost = 28800.00m , CurrencyID = 1, GCT = false},
                new Service {ServiceID = 179 , RecieptTypeID = 39 , Description = "Motor Vehicle Fitness Renewal" , Cost = 4500.00m , CurrencyID = 1, GCT = false},
                new Service {ServiceID = 180 , RecieptTypeID = 39 , Description = "Motor Vehicle Registration Certificate Renewal - 1 year, not exceeding 1199cc" , Cost = 12240.00m , CurrencyID = 1, GCT = false},
                new Service {ServiceID = 181 , RecieptTypeID = 39 , Description = "Motor Vehicle Registration Certificate Renewal - 6 months, not exceeding 1199cc" , Cost = 7620.00m , CurrencyID = 1, GCT = false},
                new Service {ServiceID = 182 , RecieptTypeID = 39 , Description = "Motor Vehicle Registration Certificate Renewal - 1 year, 1199cc – 2999cc" , Cost = 15600.00m , CurrencyID = 1, GCT = false},
                new Service {ServiceID = 183 , RecieptTypeID = 39 , Description = "Motor Vehicle Registration Certificate Renewal - 6 months, 1199cc – 2999cc" , Cost = 9300.00m , CurrencyID = 1, GCT = false},
                new Service {ServiceID = 184 , RecieptTypeID = 39 , Description = "Motor Vehicle Registration Certificate Renewal - 6 month, 3000cc – 3999cc" , Cost = 17400.00m , CurrencyID = 1, GCT = false},
                new Service {ServiceID = 186 , RecieptTypeID = 39 , Description = "Motor Vehicle Registration Certificate Renewal - 1 year, 3000cc – 3999cc" , Cost = 31800.00m , CurrencyID = 1, GCT = false},
                new Service {ServiceID = 187 , RecieptTypeID = 38 , Description = "Fitness Valet" , Cost = 2912.50m , CurrencyID = 1, GCT = false},
                new Service {ServiceID = 188 , RecieptTypeID = 38 , Description = "Normal Valet" , Cost = 2912.50m , CurrencyID = 1, GCT = false},
                new Service {ServiceID = 189 , RecieptTypeID = 40 , Description = "Fleet Management Service" , Cost = 2912.50m , CurrencyID = 1, GCT = false},
                new Service {ServiceID = 191 , RecieptTypeID = 40 , Description = "JAA Advance" , Cost = 2912.50m , CurrencyID = 1, GCT = false},

            };

            //using (var transaction = context.Database.BeginTransaction())
            //{

                services.ForEach(s => context.Service.AddOrUpdate(s));
                //context.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT dbo.Service ON;");
                context.SaveChanges();
                //context.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT dbo.Service OFF;");
                //transaction.Commit();
            //}

            var paymentTypes = new List<PaymentType>
                {
                    new PaymentType {PaymentTypeID = 1 , Description = "Cash"},
                    new PaymentType {PaymentTypeID = 2 , Description = "Credit Card Walk In"},
                    new PaymentType {PaymentTypeID = 3 , Description = "Credit Card Internet"},
                    new PaymentType {PaymentTypeID = 4 , Description = "Debit Card JN"},
                    new PaymentType {PaymentTypeID = 5 , Description = "Debit Card NCB"},
                    new PaymentType {PaymentTypeID = 6 , Description = "Debit Card BNS"},
                    new PaymentType {PaymentTypeID = 8 , Description = "Cheque"}
                };

            //using (var transaction = context.Database.BeginTransaction())
            //{

                paymentTypes.ForEach(p => context.PaymentType.AddOrUpdate(p));
                //context.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT dbo.PaymentType ON;");
                context.SaveChanges();
                //context.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT dbo.PaymentType Off;");
                //transaction.Commit();
            //}

            var documentType = new List<DocumentType>
                {
                    new DocumentType{DocumentTypeID = 1  , Description = "CS"},
                    new DocumentType{DocumentTypeID = 2  , Description = "DP"},
                    new DocumentType{DocumentTypeID = 180  , Description = "pp"},

                };

            //using (var transaction = context.Database.BeginTransaction())
            //{
                documentType.ForEach(d => context.DocumentType.AddOrUpdate(d));
                //context.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT dbo.DocumentType ON;");
                context.SaveChanges();
                //context.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [dbo].[DocumentType] OFF");
                //transaction.Commit();

            //}

            var bankCode = new List<BankCode>
            {
                new BankCode{BankCodeID = 1 , PaymentTypeID = 8 , BankCodeNumber = 130045},
                new BankCode{BankCodeID = 2 , PaymentTypeID = 1 , BankCodeNumber = 130030},
                //new BankCode{BankCodeID = 3 , PaymentTypeID = 10 , BankCodeNumber = 130000},
                new BankCode{BankCodeID = 3 , PaymentTypeID = 4 , BankCodeNumber = 130045},
                new BankCode{BankCodeID = 4 , PaymentTypeID = 6 , BankCodeNumber = 131050},
                new BankCode{BankCodeID = 5 , PaymentTypeID = 5 , BankCodeNumber = 131070},
                new BankCode{BankCodeID = 6 , PaymentTypeID = 2 , BankCodeNumber = 188090},
                new BankCode{BankCodeID = 7 , PaymentTypeID = 3 , BankCodeNumber = 188090},
                //new BankCode{BankCodeID = 8 , PaymentTypeID = 10 , BankCodeNumber = 130000},
            };
            //using (var transaction = context.Database.BeginTransaction())
            //{

                bankCode.ForEach(b => context.BankCode.AddOrUpdate(b));
                //context.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT dbo.BankCode ON;");
                context.SaveChanges();
            //context.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT dbo.BankCode OFF;");
            //transaction.Commit();
            //}

            var consumptionTaxAccount = new List<ConsumptionTaxAccount>
            { 
                new ConsumptionTaxAccount{ConsumptionTaxAccountID = 1 , AccountNumber = "228050"}
            };

            var subAccount = new List<SubAccount>
            {
                new SubAccount{SubAccountID = 1 , ReceiptTypeCategoryId = 5 , SubAccountNumber = "028-10-0" },
                new SubAccount{SubAccountID = 2 , ReceiptTypeCategoryId = 1 , SubAccountNumber = "028-14-0" },
                new SubAccount{SubAccountID = 3 , ReceiptTypeCategoryId = 4 , SubAccountNumber = "028-17-0" },
                new SubAccount{SubAccountID = 4 , ReceiptTypeCategoryId = 2 , SubAccountNumber = "000-00-0" },
                new SubAccount{SubAccountID = 5 , ReceiptTypeCategoryId = 39 , SubAccountNumber = "000-00-0" },
                new SubAccount{SubAccountID = 6 , ReceiptTypeCategoryId = 38 , SubAccountNumber = "028-16-0" }
            };

            subAccount.ForEach(i => context.SubAccount.AddOrUpdate(i));

            context.SaveChanges();

            var subAccountTax = new List<SubAccountTax>
            {
                new SubAccountTax{SubAccountTaxID = 1 , SubAccountNumber = "001-00-0"}
            };

            subAccountTax.ForEach(i => context.SubAccountTax.AddOrUpdate(i));

            context.SaveChanges();

            var subAccountBankCode = new List<SubAccountBankCode>
            {
                new SubAccountBankCode{SubAccountBankCodeID = 1 , BankCodeID = 6 , SubAccountNumber = "001-00-0" },
                new SubAccountBankCode{SubAccountBankCodeID = 2 , BankCodeID = 7 , SubAccountNumber = "001-00-0" },
                new SubAccountBankCode{SubAccountBankCodeID = 3 , BankCodeID = 1 , SubAccountNumber = "001-00-0" },
                new SubAccountBankCode{SubAccountBankCodeID = 4 , BankCodeID = 3 , SubAccountNumber = "001-00-0" },
                new SubAccountBankCode{SubAccountBankCodeID = 5 , BankCodeID = 8 , SubAccountNumber = "001-00-0" },
                //BNS Debit card 
                new SubAccountBankCode{SubAccountBankCodeID = 6 , BankCodeID = 4 , SubAccountNumber = "002-00-0" },
                new SubAccountBankCode{SubAccountBankCodeID = 7 , BankCodeID = 2 , SubAccountNumber = "001-00-0" }

            };

            subAccountBankCode.ForEach(i => context.SubAccountBankCode.AddOrUpdate(i));

            context.SaveChanges();

            var GCTIncomeAccount = new List<GCTIncomeAccount>
            {
                new GCTIncomeAccount{GCTIncomeAccountID = 1 , AccountNumber = "228050"}
            };

            GCTIncomeAccount.ForEach(i => context.GCTIncomeAccount.AddOrUpdate(i));

            context.SaveChanges();

            var incomeAccount = new List<IncomeAccountListing>
            {
                new IncomeAccountListing{IncomeAccountListingID = 3 , ServiceID = 23 , IncomeAccountNumber = 420061 },
                new IncomeAccountListing{IncomeAccountListingID = 4 , ServiceID = 24 , IncomeAccountNumber = 420062 },
                new IncomeAccountListing{IncomeAccountListingID = 5 , ServiceID = 21 , IncomeAccountNumber = 420065 },
                new IncomeAccountListing{IncomeAccountListingID = 6 , ServiceID = 15 , IncomeAccountNumber = 420130 },
                new IncomeAccountListing{IncomeAccountListingID = 7 , ServiceID = 188 , IncomeAccountNumber = 420310 },
                new IncomeAccountListing{IncomeAccountListingID = 9 , ServiceID = 187 , IncomeAccountNumber = 420310 },
                new IncomeAccountListing{IncomeAccountListingID = 10 , ServiceID = 17 , IncomeAccountNumber = 420315 },
                new IncomeAccountListing{IncomeAccountListingID = 11 , ServiceID = 16 , IncomeAccountNumber = 420317 },
                new IncomeAccountListing{IncomeAccountListingID = 12 , ServiceID = 18 , IncomeAccountNumber = 420320 },
                new IncomeAccountListing{IncomeAccountListingID = 13 , ServiceID = 158 , IncomeAccountNumber = 424150 },
                //new IncomeAccountListing{IncomeAccountListingID = 14 , ServiceID = 189 , IncomeAccountNumber = 424201 },
                //new IncomeAccountListing{IncomeAccountListingID = 15 , ServiceID = 189 , IncomeAccountNumber = 424202 },
                //new IncomeAccountListing{IncomeAccountListingID = 16 , ServiceID = 189 , IncomeAccountNumber = 424203 },
                //new IncomeAccountListing{IncomeAccountListingID = 17 , ServiceID = 189 , IncomeAccountNumber = 424204 },
                //new IncomeAccountListing{IncomeAccountListingID = 18 , ServiceID = 189 , IncomeAccountNumber = 424205 },
                //new IncomeAccountListing{IncomeAccountListingID = 19 , ServiceID = 189 , IncomeAccountNumber = 424206 },
                new IncomeAccountListing{IncomeAccountListingID = 20 , ServiceID = 161 , IncomeAccountNumber = 424300},
                new IncomeAccountListing{IncomeAccountListingID = 22 , ServiceID = 9 , IncomeAccountNumber = 424300 },
                new IncomeAccountListing{IncomeAccountListingID = 23 , ServiceID = 10 , IncomeAccountNumber = 424300 },
                new IncomeAccountListing{IncomeAccountListingID = 24 , ServiceID = 8 , IncomeAccountNumber = 424300 },
                new IncomeAccountListing{IncomeAccountListingID = 25 , ServiceID = 1 , IncomeAccountNumber = 424310 },
                new IncomeAccountListing{IncomeAccountListingID = 26 , ServiceID = 2 , IncomeAccountNumber = 424310 },
                new IncomeAccountListing{IncomeAccountListingID = 27 , ServiceID = 3 , IncomeAccountNumber = 424310},
                new IncomeAccountListing{IncomeAccountListingID = 28 , ServiceID = 4 , IncomeAccountNumber = 424310},
                new IncomeAccountListing{IncomeAccountListingID = 29 , ServiceID = 5 , IncomeAccountNumber = 424310},
                new IncomeAccountListing{IncomeAccountListingID = 30 , ServiceID = 6 , IncomeAccountNumber = 424310},
                new IncomeAccountListing{IncomeAccountListingID = 31 , ServiceID = 7 , IncomeAccountNumber = 424310},
                new IncomeAccountListing{IncomeAccountListingID = 32 , ServiceID = 7 , IncomeAccountNumber = 424310},
                new IncomeAccountListing{IncomeAccountListingID = 33 , ServiceID = 165 , IncomeAccountNumber = 424311},
                new IncomeAccountListing{IncomeAccountListingID = 34 , ServiceID = 164 , IncomeAccountNumber = 424311},
                new IncomeAccountListing{IncomeAccountListingID = 35 , ServiceID = 162 , IncomeAccountNumber = 424311},
                new IncomeAccountListing{IncomeAccountListingID = 36 , ServiceID = 19 , IncomeAccountNumber = 450010},
                new IncomeAccountListing{IncomeAccountListingID = 37 , ServiceID = 167 , IncomeAccountNumber = 450030},
                new IncomeAccountListing{IncomeAccountListingID = 38 , ServiceID = 12 , IncomeAccountNumber = 228000},
                new IncomeAccountListing{IncomeAccountListingID = 39 , ServiceID = 14 , IncomeAccountNumber = 228000},
                new IncomeAccountListing{IncomeAccountListingID = 40 , ServiceID = 175 , IncomeAccountNumber = 228000},
                new IncomeAccountListing{IncomeAccountListingID = 41 , ServiceID = 176 , IncomeAccountNumber = 228000},
                new IncomeAccountListing{IncomeAccountListingID = 42 , ServiceID = 178 , IncomeAccountNumber = 228000},
                new IncomeAccountListing{IncomeAccountListingID = 43 , ServiceID = 179 , IncomeAccountNumber = 228000},
                new IncomeAccountListing{IncomeAccountListingID = 44 , ServiceID = 180 , IncomeAccountNumber = 228000},
                new IncomeAccountListing{IncomeAccountListingID = 45 , ServiceID = 181 , IncomeAccountNumber = 228000},
                new IncomeAccountListing{IncomeAccountListingID = 46 , ServiceID = 182 , IncomeAccountNumber = 228000},
                new IncomeAccountListing{IncomeAccountListingID = 47 , ServiceID = 183 , IncomeAccountNumber = 228000},
                new IncomeAccountListing{IncomeAccountListingID = 48 , ServiceID = 184 , IncomeAccountNumber = 228000},
                new IncomeAccountListing{IncomeAccountListingID = 49 , ServiceID = 186 , IncomeAccountNumber = 228000},
                new IncomeAccountListing{IncomeAccountListingID = 50 , ServiceID = 11 , IncomeAccountNumber = 228000},
                new IncomeAccountListing{IncomeAccountListingID = 51 , ServiceID = 179 , IncomeAccountNumber = 228000},
                new IncomeAccountListing{IncomeAccountListingID = 52 , ServiceID = 166 , IncomeAccountNumber = 424150},
                new IncomeAccountListing{IncomeAccountListingID = 53 , ServiceID = 22 , IncomeAccountNumber = 420059},
                new IncomeAccountListing{IncomeAccountListingID = 54 , ServiceID = 8 , IncomeAccountNumber = 424300}

            };

            //using (var transaction = context.Database.BeginTransaction())
            //{

                incomeAccount.ForEach(i => context.IncomeAccountListing.AddOrUpdate(i));
                //context.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT dbo.IncomeAccountListing ON;");
                context.SaveChanges();
            //context.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT dbo.IncomeAccountListing ON;");
            //transaction.Commit();

            //}


            var customerIdentification = new List<CustomerIdentification>
            { 
                new CustomerIdentification{CustomerIdentificationID = 1 , ReceiptTypeCategoryID = 1 , CUSTID = "CSHDRVA"},
                new CustomerIdentification{CustomerIdentificationID = 2 , ReceiptTypeCategoryID = 2 , CUSTID = "CSHIRD"},
                new CustomerIdentification{CustomerIdentificationID = 3 , ReceiptTypeCategoryID = 39 , CUSTID = "CSHIRD"},
                new CustomerIdentification{CustomerIdentificationID = 4 , ReceiptTypeCategoryID = 4 , CUSTID = ""},
                new CustomerIdentification{CustomerIdentificationID = 5 , ReceiptTypeCategoryID = 5 , CUSTID = "CSHMSUB"},
                new CustomerIdentification{CustomerIdentificationID = 6 , ReceiptTypeCategoryID = 38 , CUSTID = "CSHMSUB"},

            };

            customerIdentification.ForEach(i => context.CustomerIdentification.AddOrUpdate(i));

            context.SaveChanges();

        }







    }
}
