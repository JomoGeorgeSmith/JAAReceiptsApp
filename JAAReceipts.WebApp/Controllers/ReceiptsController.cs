using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using JAAReceipts.WebApp.Data;
using JAAReceipts.WebApp.Models;
using JAAReceipts.WebApp.ViewModel;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using Mozzarella;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Invoicer.Models;
using Invoicer.Services;
using System.Reflection.Emit;
using System.Diagnostics;
using System.Security.Policy;
using System.Runtime.CompilerServices;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Reflection;
using System.Drawing;
using System.Threading;
using System.Web;



//using JAAReceipts.WebApp.Migrations;

namespace JAAReceipts.WebApp.Views
{
    public class ReceiptsController : Controller
    {
        private JAAReceiptsContext db = new JAAReceiptsContext();
        ReceiptViewModel viewModel = new ReceiptViewModel();
        public Guid currentReceiptNumber = new Guid();
        public DateTime currentDateTime = new DateTime();
        //public int currencyIDFromView = new int();
        public ActionResult ReceiptsViewModel()
        {
            ReceiptViewModel viewModel = new ReceiptViewModel();
            var receiptTypeCategories = db.ReceiptTypeCategory.ToList();
            //receiptTypeCategories.OrderBy(i => i.Description) ;
            if (receiptTypeCategories != null)
            {
                viewModel.AllReceiptTypeCategories = receiptTypeCategories;

            }

            var services = db.Service.ToList();
            if (services != null)
            {
                viewModel.AllServices = services;
            }

            return View(viewModel);
        }

        public ActionResult GetReceiptCategories()
        {
            var items = db.ReceiptTypeCategory.ToList();
            if (items != null)
            {
                ViewBag.data = items;
            }

            return View();
        }

        // GET: Receipts
        public ActionResult Index()
        {
            var receipt = db.Receipt
                .Include(r => r.DocumentType)
                .Include(r => r.ReceiptItems)
                .Include(r => r.Currency);

            ReceiptViewModel[] vm = new ReceiptViewModel[receipt.Count()];

            List<ReceiptViewModel> LVM = new List<ReceiptViewModel>();

            var count = 0;
            foreach (var i in receipt)
            {

                vm[count] = new ReceiptViewModel
                {
                    Receipt = i,
                    ItemsOnReceipt = GetServicesOnReceipt(Convert.ToInt32(i.ReceiptID))
                };

                LVM.Add(vm[count]);
                count++;
            }

            return View(LVM.ToList());

        }

        public ActionResult ReceiptListings()
        {
            var receiptListing = PullReceiptListings();

           //ReceiptViewModel LVM = new ReceiptViewModel();

            //LVM.ReceiptListings.AddRange(receiptListing);

           // viewModel.ReceiptListings.AddRange(receiptListing);

            return View(receiptListing);
        }

        public ActionResult GenerateBatch()
        {

            //GenerateCSVBatch();
           
            return View();
        }


        public string GetServicesOnReceipt(int receiptId)
        {

            var services = (from c in db.Receipt
                       join t in db.ReceiptItem on c.ReceiptID equals t.ReceiptID
                       join s in db.Service on t.ServiceID equals s.ServiceID
                            where c.ReceiptID == receiptId
                            select new { s.Description  })
             .ToList();

            StringBuilder sb = new StringBuilder();
            String[] sr = new string[services.Count];
            var i = 0;

            foreach (var s in services)
            {
                //sb.Append(s.Description + " " + " + " + " ");
                sr[i] = s.Description;
                i++;

            }

            // i = 0;


            //var servicesFormatted = sb.ToString();
            var servicesFormatted2 = sb.AppendJoin(" + ", sr);
            return (servicesFormatted2.ToString());
           // return (servicesFormatted);
        }


        public string GetServicesOnReceiptItems(int receiptId)
        {

            var services = (from c in db.Receipt
                            join t in db.ReceiptItem on c.ReceiptID equals t.ReceiptID
                            join s in db.Service on t.ServiceID equals s.ServiceID
                            where c.ReceiptID == receiptId
                            select new { s.Description })
             .ToList();

            //services = db.Service.Where(s => s.RecieptTypeID == id).ToList();

            StringBuilder sb = new StringBuilder();
            String[] sr = new string[services.Count];
            var i = 0;

            foreach (var s in services)
            {
                //sb.Append(s.Description + " " + " + " + " ");
                sr[i] = s.Description;
                i++;
            }

            // i = 0;
            //var servicesFormatted = sb.ToString();
            var servicesFormatted2 = sb.AppendJoin(" + ", sr);
            return (servicesFormatted2.ToString());
            // return (servicesFormatted);
        }


        // GET: Receipts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = db.Receipt.Find(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            return View(receipt);
        }

        public ActionResult Complete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = db.Receipt.Find(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }

            viewModel.Receipt = receipt;
            viewModel.Receipt.ReceiptItems = GetReceiptItems(receipt.ReceiptID.ToString());

            //var receiptType = db.ReceiptTypeCategory.Where(i => i.ReceiptTypeCategoryID == receipt.ReceiptItems.)
            //var l = Convert.ToInt32(receipt.ReceiptID );  
            //viewModel.ServicesOnReceipt = GetServicesOnReceipt(l);

            return View(viewModel);
        }

        public ActionResult CompleteInvoice(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = db.Receipt.Find(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }

            viewModel.Receipt = receipt;
            viewModel.Receipt.ReceiptItems = GetReceiptItems(receipt.ReceiptID.ToString());
            //var l = Convert.ToInt32(receipt.ReceiptID );  
            //viewModel.ServicesOnReceipt = GetServicesOnReceipt(l);

            return View(viewModel);
        }


        public ActionResult CompleteAssetDisposal(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = db.Receipt.Find(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }

            viewModel.Receipt = receipt;
            viewModel.Receipt.ReceiptItems = GetReceiptItems(receipt.ReceiptID.ToString());
            //var l = Convert.ToInt32(receipt.ReceiptID );  
            //viewModel.ServicesOnReceipt = GetServicesOnReceipt(l);

            return View(viewModel);
        }


        // GET: Receipts/Create
        public ActionResult Create()
        {

            //ReceiptViewModel viewModel = new ReceiptViewModel();

            var allDocumentTypes = db.DocumentType.ToList();
            if(allDocumentTypes != null)
            {
                viewModel.AllDocumentTypes = allDocumentTypes;
            }

            var receiptTypeCategories = db.ReceiptTypeCategory.ToList();
            if (receiptTypeCategories != null)
            {
                viewModel.AllReceiptTypeCategories = receiptTypeCategories;
            }

            var cooperateClients = db.CooperateClients.ToList();
            if (cooperateClients != null)
            {
                viewModel.CoopererateClients = cooperateClients;
            }

            var paymentTypes = db.PaymentType.ToList();
            if(paymentTypes != null)
            {
                viewModel.AllPaymentTypes = paymentTypes;
            }

            var currencies = db.Currency.ToList();
            if(currencies != null)
            {
                viewModel.Currencies = currencies; 
            }

          //  viewModel.GUID = NewGUID();

            //var date = new DateTime();
            viewModel.Date = DateTime.Now;

            //currentReceiptNumber = viewModel.GUID;
            //currentDateTime = viewModel.Date;

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection form)
        {
            Receipt receipt = new Receipt();
            GCTRecord gctRecord = new GCTRecord();
            BankCodeRecord bankCodeRecord = new BankCodeRecord();
            var serviceID = Convert.ToInt32(form["ServiceID"]);
            bool hasGCT = false;

            List<decimal> tax = new List<decimal>();

            receipt.Date = Convert.ToDateTime(DateTime.Now);
            receipt.AdditionalInfo = Convert.ToString(Request.Form["Receipt.AdditionalInfo"]);
            receipt.CurrencyID = currencyIDFromView;
            var bankCode = GetBankCode(Convert.ToInt32(Request.Form["Receipt.PaymentTypeID"]));
            receipt.BankAccountNumber = Convert.ToInt64(bankCode);

            //receipt.CooperateClientID = cooperateClientId;
            receipt.LineOfBusinessAccountNumber = Convert.ToString(GetLineOfBusinessAccountNumber());
            receipt.ReceiptCode = Convert.ToInt32(GetReceiptCode());
            receipt.ReceivedFrom = Convert.ToString(Request.Form["Receipt.ReceivedFrom"]);
            receipt.TotalAmount = Convert.ToDecimal(Request.Form["Receipt.TotalAmount"]);
            receipt.PaymentTypeID = Convert.ToInt32(Request.Form["Receipt.PaymentTypeID"]);
            receipt.DocumentTypeID = Convert.ToInt32(Request.Form["Receipt.DocumentTypeID"]);

            if (receipt.PaymentTypeID == 2 || receipt.PaymentTypeID == 3 ||
                receipt.PaymentTypeID == 4 || receipt.PaymentTypeID == 5 ||
                 receipt.PaymentTypeID == 6 || receipt.PaymentTypeID == 13)
            {
                receipt.LastFourDigits = Convert.ToInt32(Request.Form["Receipt.LastFourDigits"]);
            }

            if (receipt.PaymentTypeID == 7 || receipt.PaymentTypeID == 8)
            {
                receipt.ChequeNumber = Request.Form["Receipt.ChequeNumber"];
            }

            //Invoice
            if (serviceID == 26)
            {
                receipt.CustomerID = Convert.ToString(Request.Form["Receipt.CustomerID"]);
            }

            receipt.IncomeAccountNumber = Convert.ToInt32(GetIncomeAccountNumber(serviceID));

            db.Receipt.Add(receipt);

            db.SaveChanges();

            receipt.ReceiptNumber = GenerateReceiptNumber(receipt.ReceiptID);

            ReceiptItem[] items = new ReceiptItem[ServicesFromView.Count];

            ServiceRecord[] serviceRecord = new ServiceRecord[ServicesFromView.Count];

            List<ServiceRecord> serviceRecords = new List<ServiceRecord>();

            List<ReceiptItem> ReceiptItems = new List<ReceiptItem>();

            var serv = ServicesFromView.ToArray();

            var amt = AmountsFromView.ToArray();

            var qnt = QuantitiesFromView.ToArray();

            var inf = AdditionalInfoFromView.ToArray();

            bool invoice = false;

            bool assetDisposal = false;

            var custID = "";

            Service currentService = new Service();

            for (int i = 0; i < ServicesFromView.ToArray().Length; i++)
            {
                custID = GetCUSTID(GetReceiptCategory(Convert.ToInt32(serv[i])));

                var service = GetService(Convert.ToInt32(serv[i]));
                currentService = service;

                if (service.GCT == true)
                {
                    //tax.Add(CalculateGCT(Convert.ToInt32(amt[i])));
                    tax.Add(CalculateGCT(Convert.ToDecimal(amt[i])));
                }
                if (Convert.ToInt32(serv[i]) == 26 || Convert.ToInt32(serv[i]) == 189 || Convert.ToInt32(serv[i]) == 191)
                {
                    invoice = true;

                    items[i] = new ReceiptItem
                    {
                        ReceiptID = receipt.ReceiptID,
                        ServiceID = Convert.ToInt32(serv[i]),
                        Amount = Convert.ToDecimal(amt[i]),
                        AdditionalInformation = Convert.ToString(inf[i])

                        //CurrencyID = currencyID

                    };
                }

                else if (Convert.ToInt32(serv[i]) == 15)
                {
                    assetDisposal = true;

                    items[i] = new ReceiptItem
                    {
                        ReceiptID = receipt.ReceiptID,
                        ServiceID = Convert.ToInt32(serv[i]),
                        Amount = Convert.ToDecimal(amt[i]),
                        AdditionalInformation = Convert.ToString(inf[i])
                        //CurrencyID = currencyID
                    };

                    serviceRecord[i] = new ServiceRecord
                    {
                        AccountNumber = Convert.ToString(GetIncomeAccountNumber(serviceID)),
                        SubAccount = GetSubAccountForService(GetReceiptCategory(Convert.ToInt32(serv[i]))),
                        // Amount = AdjustAmountForGCT( Convert.ToDecimal(amt[i]) , currentService) ,
                        Amount = Convert.ToDecimal(amt[i]),
                        DocumentType = "CS",
                        CustomerID = GetCUSTID(GetReceiptCategory(Convert.ToInt32(serv[i]))),
                        TransactionDate = Convert.ToDateTime(DateTime.Now),
                        ReferneceNumber = Convert.ToString(receipt.ReceiptNumber),
                        TransactionDetails = GenerateTransactionDescription(receipt.ReceiptNumber, receipt.ReceivedFrom, service.Description),
                        Type = "SVC",
                        BankAccountNumber = Convert.ToString(receipt.BankAccountNumber)

                    };

                    ReceiptItems.Add(items[i]);
                    serviceRecords.Add(serviceRecord[i]);

                }

                else
                {
                    items[i] = new ReceiptItem
                    {
                        ReceiptID = receipt.ReceiptID,
                        ServiceID = Convert.ToInt32(serv[i]),
                        Amount = Convert.ToDecimal(amt[i]),
                        Quantity = Convert.ToInt32(qnt[i]),
                        GCT = CalculateGCT(Convert.ToDecimal(amt[i]))
                    };

                



                    serviceRecord[i] = new ServiceRecord
                    {
                        AccountNumber = Convert.ToString(GetIncomeAccountNumber(serviceID)),
                        SubAccount = GetSubAccountForService(GetReceiptCategory(Convert.ToInt32(serv[i]))),
                        // Amount = AdjustAmountForGCT( Convert.ToDecimal(amt[i]) , currentService) ,
                        Amount = Convert.ToDecimal(amt[i]),
                        DocumentType = "CS",
                        CustomerID = GetCUSTID(GetReceiptCategory(Convert.ToInt32(serv[i]))),
                        TransactionDate = Convert.ToDateTime(DateTime.Now),
                        ReferneceNumber = Convert.ToString(receipt.ReceiptNumber),
                        TransactionDetails = GenerateTransactionDescription(receipt.ReceiptNumber, receipt.ReceivedFrom, service.Description),
                        Type = "SVC",
                        BankAccountNumber = Convert.ToString(receipt.BankAccountNumber)

                    };

                    //}
                    //custID = GetCUSTID(GetReceiptCategory(Convert.ToInt32(serv[i])));

                



                ReceiptItems.Add(items[i]);
                serviceRecords.Add(serviceRecord[i]);
            }

        }

            if (tax.Count > 0)
            {
                hasGCT = true;
                gctRecord.AccountNumber = GetGCTIncomeAccount();
                gctRecord.Amount = tax.Sum();
                gctRecord.CustomerID = custID;
                gctRecord.DocumentType = "CS";
                gctRecord.ReferneceNumber = receipt.ReceiptNumber;
                gctRecord.SubAccount = GetGCTSubAccount();
                gctRecord.TransactionDate = Convert.ToDateTime(DateTime.Now);
                gctRecord.TransactionDetails = "General Consumption Tax";
                gctRecord.Type = "GCT";
                gctRecord.BankAccountNumber = Convert.ToString(receipt.BankAccountNumber);


            }

            bankCodeRecord.AccountNumber = Convert.ToString(receipt.BankAccountNumber);
            var bank = GetBankCodeObject(bankCodeRecord.AccountNumber);
            //bankCodeRecord.Amount = receipt.TotalAmount + tax.Sum();
            //bankCodeRecord.Amount = CalculateGCTTotal( receipt.TotalAmount );
            bankCodeRecord.Amount = receipt.TotalAmount;
            bankCodeRecord.CustomerID = custID;
            bankCodeRecord.DocumentType = "CS";
            bankCodeRecord.ReferneceNumber = receipt.ReceiptNumber;
            bankCodeRecord.SubAccount = GetSubAccountForBankCode(bank.BankCodeID);
            bankCodeRecord.TransactionDate = Convert.ToDateTime(DateTime.Now);
            bankCodeRecord.TransactionDetails = GenerateTransactionDescription(receipt.ReceiptNumber, receipt.ReceivedFrom, currentService.Description);
            bankCodeRecord.Type = "BNK";

            ServicesFromView.Clear();
            AmountsFromView.Clear();
            QuantitiesFromView.Clear();
            AdditionalInfoFromView.Clear();
            custID = null;
            tax.Clear();
            //currencyIDFromView = null;

            if (ModelState.IsValid)
            {
                //db.Receipt.Add(receipt);            
                db.ReceiptItem.AddRange(ReceiptItems);
                db.ServiceRecord.AddRange(serviceRecords);
                db.BankCodeRecord.Add(bankCodeRecord);

                if (hasGCT == true)
                {
                    db.GCTRecord.Add(gctRecord);
                }

                db.SaveChanges();

                //receipt.ReceiptNumber = GenerateReceiptNumber(receipt.ReceiptID);

                //db.SaveChanges();

                //db.ServiceRecord.AddRange(serviceRecords);
                //db.BankCodeRecord.Add(bankCodeRecord);

                //db.SaveChanges();



                if (invoice == true)
                {
                    return RedirectToAction("CompleteInvoice", new { id = receipt.ReceiptID });
                }

                if (assetDisposal == true)
                {
                    return RedirectToAction("CompleteAssetDisposal", new { id = receipt.ReceiptID });
                }

                else
                {
                    return RedirectToAction("Complete", new { id = receipt.ReceiptID });
                }

            }

        

            return View(receipt);
        }



        //public List<ReceiptListing> RetrieveBatchDetails(DateTime startDate , DateTime endDate , string bankAccountNumber)
        //{
        //    var listings = (from i in db.ServiceRecord
        //                    select new { i.DocumentType, i.TransactionDate, i.ReferneceNumber, i.CustomerID, i.AccountNumber,
        //                        i.SubAccount, i.BankAccountNumber,i.TransactionDetails, i.Amount, i.Type }).Where(x => x.TransactionDate >= startDate && x.TransactionDate <= endDate && x.BankAccountNumber == bankAccountNumber )
        //                     .Union(from t in db.GCTRecord
        //                           select new { t.DocumentType, t.TransactionDate, t.ReferneceNumber, t.CustomerID, t.AccountNumber,
        //                               t.SubAccount, t.BankAccountNumber , t.TransactionDetails , t.Amount , t.Type}).Where(x => x.TransactionDate >= startDate && x.TransactionDate <= endDate && x.BankAccountNumber == bankAccountNumber)
        //                    .ToList();


        //    List<ReceiptListing> rl = new List<ReceiptListing>();

        //    ReceiptListing[] rlArray = new ReceiptListing[listings.Count()];


        //    for (int i = 0; i < listings.ToArray().Length; i++)
        //    {
        //        rlArray[i] = new ReceiptListing
        //        {
        //            DocumentType = listings[i].DocumentType,
        //            TransactionDate = listings[i].TransactionDate,
        //            ReferneceNumber = listings[i].ReferneceNumber,
        //            CustomerID = listings[i].CustomerID,
        //            AccountNumber = listings[i].AccountNumber,
        //            SubAccount = listings[i].SubAccount,
        //            TransactionDetails = listings[i].TransactionDetails,
        //            CreditAmount = listings[i].Amount,
        //            DebitAmount = 0
        //        };

        //        rl.Add(rlArray[i]);
        //    }

        //    return rl;
        //}


        public List<ReceiptListingCSV> RetrieveBatchDetails(DateTime startDate, DateTime endDate, string bankAccountNumber)
        {
            var listings = (from i in db.ServiceRecord
                            select new
                            {
                                i.DocumentType,
                                i.TransactionDate,
                                i.ReferneceNumber,
                                i.CustomerID,
                                i.AccountNumber,
                                i.SubAccount,
                                i.BankAccountNumber,
                                i.TransactionDetails,
                                i.Amount,
                                i.Type
                            }).Where(x => x.TransactionDate >= startDate && x.TransactionDate <= endDate && x.BankAccountNumber == bankAccountNumber)
                             .Union(from t in db.GCTRecord
                                    select new
                                    {
                                        t.DocumentType,
                                        t.TransactionDate,
                                        t.ReferneceNumber,
                                        t.CustomerID,
                                        t.AccountNumber,
                                        t.SubAccount,
                                        t.BankAccountNumber,
                                        t.TransactionDetails,
                                        t.Amount,
                                        t.Type
                                    }).Where(x => x.TransactionDate >= startDate && x.TransactionDate <= endDate && x.BankAccountNumber == bankAccountNumber)
                            .ToList();


            List<ReceiptListingCSV> rl = new List<ReceiptListingCSV>();

            ReceiptListingCSV[] rlArray = new ReceiptListingCSV[listings.Count()];


            for (int i = 0; i < listings.ToArray().Length; i++)
            {
                rlArray[i] = new ReceiptListingCSV
                {
                    EntryType = listings[i].DocumentType,
                    TransactionDate = listings[i].TransactionDate,
                    ReferneceNumber = listings[i].ReferneceNumber,
                    CustomerID = listings[i].CustomerID,
                    AccountNumber = listings[i].AccountNumber,
                    SubAccount = listings[i].SubAccount,
                    Description = listings[i].TransactionDetails,
                    CreditAmount = listings[i].Amount,
                    DebitAmount = 0,
                    CATran = "CATran"
                };

                rl.Add(rlArray[i]);
            }

            return rl;
        }
        public List<BatchHeader> RetrieveBatchHeader(DateTime startDate, DateTime endDate, string bankAccountNumber)
        {
            var header = (from x in db.BankCodeRecord
                          where x.TransactionDate >= startDate && x.TransactionDate <= endDate && x.AccountNumber == bankAccountNumber
                          let dt = x.TransactionDate
                          group x by new { y = dt.Year, m = dt.Month, d = dt.Day, x.AccountNumber, x.SubAccount } into g
                          select new { g.Key.AccountNumber, g.Key.SubAccount, Total = g.Sum(x => x.Amount) }).ToList();

            BatchHeader bh = new BatchHeader();
            List<BatchHeader> bhList = new List<BatchHeader>();

            if (header.Count > 0)
            {

                foreach (var i in header)
                {

                    bh.BankAccount = i.AccountNumber;
                    bh.BankSubAccount = i.SubAccount;
                    bh.ControlTotal = i.Total;
                    bh.BatchDate = startDate;
                    bh.Batch = "BATCH";
                    bh.PeriodToPost = "202008";
                    bh.ReconciliationMode = "B";
                    bh.BatchHandeling = "B";

                }



                bhList.Add(bh);

            }
            return bhList; 
        }

        public void GenerateCSVForBatchHeader()
        {

            string subfoldername = "Documents";
            string filename = "file.csv";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, subfoldername, filename);

            var records = RetrieveBatchHeader(new DateTime(2020, 11, 15, 00, 00, 00), new DateTime(2020, 11, 15, 23, 59, 59), "130030");

            //using (var writer = new StreamWriter("C:\\Users\\Jomo\\Documents\\file.csv"))
            using (var writer = new StreamWriter(path))

            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
            }
        }

        public void GenerateCSVForBatchDetails()
        {
            string subfoldername = "Documents";
            string filename = "file.csv";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, subfoldername, filename);

            var records =  RetrieveBatchDetails(new DateTime(2020, 11, 15, 00, 00, 00), new DateTime(2020, 11, 15, 23, 59, 59), "130030");

            //using (var writer = new StreamWriter("C:\\Users\\Jomo\\Documents\\file.csv"))
            using (var writer = new StreamWriter(path))

            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
            }

        }

        public void GenerateCSVBatch(DateTime startDate , DateTime endDate , string bankAccountNumber)
        {

            string subfoldername = "Documents";
            string filename = "file.csv";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, subfoldername, filename);


            var header = RetrieveBatchHeader(startDate, endDate, bankAccountNumber);

            var records = RetrieveBatchDetails(startDate, endDate, bankAccountNumber);

            //using (var writer = new StreamWriter("C:\\Users\\Jomo\\Documents\\file.csv"))
            using (var writer = new StreamWriter(path))

            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {

                csv.WriteRecords(header);
            }

            // Append to the file.
            //using (var stream = System.IO.File.Open("C:\\Users\\Jomo\\Documents\\file.csv", FileMode.Append))
            using (var stream = System.IO.File.Open(path, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                // Don't write the header again.
                csv.Configuration.HasHeaderRecord = true;
                csv.WriteRecords(records);
            }

        }

        public void GenerateCSVBatch()
        {
            string subfoldername = "Documents";
            string filename = "file.csv";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, subfoldername, filename);

            //using (var stream = System.IO.File.Create("C:\\Users\\Jomo\\Documents\\file.csv") );    

            using (var stream = System.IO.File.Create(path)) ;

            var accountNumbers = db.BankCode.ToList();

            foreach(var i in accountNumbers)
            {

                var header = RetrieveBatchHeader(new DateTime(2020, 11, 15, 00, 00, 00), new DateTime(2020, 11, 15, 23, 59, 59), Convert.ToString( i.BankCodeNumber) );

                var records = RetrieveBatchDetails(new DateTime(2020, 11, 15, 00, 00, 00), new DateTime(2020, 11, 15, 23, 59, 59), Convert.ToString(i.BankCodeNumber));

                //using (var stream = System.IO.File.Open("C:\\Users\\Jomo\\Documents\\file.csv", FileMode.Append))
                using (var stream = System.IO.File.Open(path, FileMode.Append))
                using (var writer = new StreamWriter(stream))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    // Don't write the header again.
                    csv.Configuration.HasHeaderRecord = true;
                    if (header.Count >  0)
                    {
                        csv.WriteRecords(header);
                    }

                    if (records.Count > 0)
                    {
                        csv.WriteRecords(records);

                    }
                }
            }

            //var header = RetrieveBatchHeader(new DateTime(2020, 11, 15, 00, 00, 00), new DateTime(2020, 11, 15, 23, 59, 59), "130030");

            //var records = RetrieveBatchDetails(new DateTime(2020, 11, 15, 00, 00, 00), new DateTime(2020, 11, 15, 23, 59, 59), "130030");

            //using (var writer = new StreamWriter("C:\\Users\\Jomo\\Documents\\file.csv"))

            //using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            //{

            //    csv.WriteRecords(header);
            //}


            // Append to the file.
            //using (var stream = System.IO.File.Open("C:\\Users\\Jomo\\Documents\\file.csv", FileMode.Append))
            //using (var writer = new StreamWriter(stream))
            //using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            //{
            //    // Don't write the header again.
            //    csv.Configuration.HasHeaderRecord = true;
            //    csv.WriteRecords(records);
            //}

        }

        //public void GenerateCSVBatch()
        //{
        //    var header = RetrieveBatchHeader(new DateTime(2020, 11, 15, 00, 00, 00), new DateTime(2020, 11, 15, 23, 59, 59), "130030");

        //    var records = RetrieveBatchDetails(new DateTime(2020, 11, 15, 00, 00, 00), new DateTime(2020, 11, 15, 23, 59, 59), "130030");

        //    using (var writer = new StreamWriter("C:\\Users\\Jomo\\Documents\\file.csv"))

        //    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        //    {

        //        csv.WriteRecords(header);
        //    }

        //    // Append to the file.
        //    using (var stream = System.IO.File.Open("C:\\Users\\Jomo\\Documents\\file.csv", FileMode.Append))
        //    using (var writer = new StreamWriter(stream))
        //    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        //    {
        //        // Don't write the header again.
        //        csv.Configuration.HasHeaderRecord = true;
        //        csv.WriteRecords(records);
        //    }

        //}

        public List<ReceiptListing> PullReceiptListings()
        {
            var listings = (from i in db.ServiceRecord
                            select new { i.DocumentType , i.TransactionDate , i.ReferneceNumber ,i.CustomerID , i.AccountNumber ,
                                i.SubAccount , i.TransactionDetails , i.Amount , i.Type})
                            .Union(from g in db.BankCodeRecord
                                   select new { g.DocumentType, g.TransactionDate, g.ReferneceNumber, g.CustomerID, g.AccountNumber,
                                       g.SubAccount, g.TransactionDetails , g.Amount , g.Type})
                            .Union(from t in db.GCTRecord
                                   select new { t.DocumentType, t.TransactionDate, t.ReferneceNumber, t.CustomerID, t.AccountNumber,
                                       t.SubAccount, t.TransactionDetails , t.Amount , t.Type})
                            .ToList();

            List<ReceiptListing> rl = new List<ReceiptListing>();

            ReceiptListing[] rlArray = new ReceiptListing[listings.Count()];

            for (int i = 0; i < listings.ToArray().Length; i++)
            {
                //GCT account
                if (listings[i].Type == "GCT")
                {
                    rlArray[i] = new ReceiptListing
                    {
                        DocumentType = listings[i].DocumentType,
                        TransactionDate = listings[i].TransactionDate,
                        ReferneceNumber = listings[i].ReferneceNumber,
                        CustomerID = listings[i].CustomerID,
                        AccountNumber = listings[i].AccountNumber,
                        SubAccount = listings[i].SubAccount,
                        TransactionDetails = listings[i].TransactionDetails ,
                        CreditAmount = listings[i].Amount,
                        DebitAmount = 0
                       
                    };

                }

                //Service 
                if (listings[i].Type == "SVC")
                {
                    rlArray[i] = new ReceiptListing
                    {
                        DocumentType = listings[i].DocumentType,
                        TransactionDate = listings[i].TransactionDate,
                        ReferneceNumber = listings[i].ReferneceNumber,
                        CustomerID = listings[i].CustomerID,
                        AccountNumber = listings[i].AccountNumber,
                        SubAccount = listings[i].SubAccount,
                        TransactionDetails = listings[i].TransactionDetails,
                        CreditAmount = listings[i].Amount,
                        DebitAmount = 0
                    };
                }

                //BankCode
                if (listings[i].Type == "BNK")
                {
                    rlArray[i] = new ReceiptListing
                    {
                        DocumentType = listings[i].DocumentType,
                        TransactionDate = listings[i].TransactionDate,
                        ReferneceNumber = listings[i].ReferneceNumber,
                        CustomerID = listings[i].CustomerID,
                        AccountNumber = listings[i].AccountNumber,
                        SubAccount = listings[i].SubAccount,
                        TransactionDetails = listings[i].TransactionDetails,
                        CreditAmount = 0,
                        DebitAmount = listings[i].Amount

                    };
                }

                rl.Add(rlArray[i]);

            }

            //for (int i = 0; i < services.Length; i++)
            //{
            //    items[i] = new ReceiptItem
            //    {
            //        ReceiptID = receipt.ReceiptID,
            //        ServiceID = Convert.ToInt32(services[i])
            //    };

            //    ReceiptItems.Add(items[i]);
            //}

            return rl;
            
        }


        public string GetCUSTID(int ReceiptTypeCategory)
        {
            var custID = db.CustomerIdentification.FirstOrDefault(i => i.ReceiptTypeCategoryID == ReceiptTypeCategory);
            return custID.CUSTID; 
        }

        public string GetBankCode(int paymentTypeId)
        {
            //All USD goes to this account

            //Change to database call 
            //if (currencyIDFromView == 2)
            //{
            //    return "131030";
            //}

            //else
            //{

                var bankCode = db.BankCode.Where(p => p.PaymentTypeID == paymentTypeId);

                BankCode bk = new BankCode();

                foreach (var b in bankCode)
                {
                    bk.BankCodeID = b.BankCodeID;
                    bk.PaymentTypeID = b.PaymentTypeID;
                    bk.BankCodeNumber = b.BankCodeNumber;
                }

                return bk.BankCodeNumber.ToString();
            //}
        }

        public Service GetService (int id)
        {
            var service = db.Service.Find(id);
            return service;
        }

        public string GetSubAccountForBankCode(int bankCodeID)
        {
            var subAccount = db.SubAccountBankCode.FirstOrDefault(i => i.BankCodeID == bankCodeID);
            return subAccount.SubAccountNumber; 
        }

        public BankCode GetBankCodeObject(string  AccountNumber)
        {

            var n = Convert.ToInt64(AccountNumber);

            var bankCode = db.BankCode.FirstOrDefault(i => i.BankCodeNumber == n);
            return bankCode;
        }

        public int GetReceiptCategory(int serviceId)
        {
            var service= db.Service.Find(serviceId);
            return service.RecieptTypeID;
        }

        public string GetSubAccountForService(int ReceiptTypeCategoryId)
        {
            var subAccount = db.SubAccount.FirstOrDefault(i => i.ReceiptTypeCategoryId == ReceiptTypeCategoryId);

            return subAccount.SubAccountNumber;
            
        }

        public string GetGCTIncomeAccount()
        {
            var gctAccount = db.GCTIncomeAccount.Find(1);
            return gctAccount.AccountNumber;
        }

        public string GetGCTSubAccount()
        {
            var gctSubAccount = db.SubAccountTax.Find(1);
            return gctSubAccount.SubAccountNumber;
        }

        public decimal CalculateGCT(decimal amount)
        {
            //decimal gct = 0.15m;

            //var d = AdjustAmountForGCT(amount);

            //decimal adjusted = d * gct;

            //return adjusted; 

            decimal gct = 0.15m;

            var d = amount;

            decimal adjusted = d * gct;

            return adjusted;
        }

        public decimal CalculateGCT2(decimal amount , Service service)
        {

            decimal gct = 0.15m;

            if (service.GCT == true)
            {
                var d = amount;

                decimal adjusted = d * gct;

                return adjusted;
            }

            else
            {
                return 0m;

            }
          

   
        }

        public decimal AdjustAmountForGCT(decimal amount)
        {
                decimal adjusted = (amount / 1.15m);
                return adjusted;      
        }

        public decimal AdjustAmountForGCT(decimal amount , Service service)
        {

            if (service.GCT == true)
            {


                decimal adjusted = (amount / 1.15m);
                return adjusted;
            }

            else
            {
                return amount;
            }
        }

        public decimal CalculateGCTTotal(decimal amount)
        {
            decimal gct = 0.15m;

            decimal adjusted = (amount * gct) + amount;

            return adjusted;
        }

        public long GetIncomeAccountNumber(int serviceID )
        {

            IncomeAccountListing incomeAccount = new IncomeAccountListing();


            //   if(cooperateClientID != null)
            //    {
            //        var listing = db.IncomeAccountListing.Where(i => i.CooperateClientID == cooperateClientID && i.ServiceID == serviceID);

            //        foreach(var l in listing)
            //        {
            //            incomeAccount.CooperateClientID = l.CooperateClientID;
            //            incomeAccount.IncomeAccountNumber = l.IncomeAccountNumber;
            //            incomeAccount.ServiceID = l.ServiceID;
            //            incomeAccount.IncomeAccountListingID = l.IncomeAccountListingID;
            //        }

            //        return incomeAccount.IncomeAccountNumber;
            //    }
            //    else
            //    {
            //        var listing = db.IncomeAccountListing.Where(i => i.ServiceID == serviceID && i.CooperateClientID == null);
            //        foreach (var l in listing)
            //        {
            //            incomeAccount.CooperateClientID = l.CooperateClientID;
            //            incomeAccount.IncomeAccountNumber = l.IncomeAccountNumber;
            //            incomeAccount.ServiceID = l.ServiceID;
            //            incomeAccount.IncomeAccountListingID = l.IncomeAccountListingID;
            //        }

            //        return incomeAccount.IncomeAccountNumber;
            //    }

            var listing = db.IncomeAccountListing.Where(i => i.ServiceID == serviceID );
            foreach (var l in listing)
            {
                //incomeAccount.CooperateClientID = l.CooperateClientID;
                incomeAccount.IncomeAccountNumber = l.IncomeAccountNumber;
                incomeAccount.ServiceID = l.ServiceID;
                incomeAccount.IncomeAccountListingID = l.IncomeAccountListingID;
            }

            return incomeAccount.IncomeAccountNumber;

        }

        public string GetLineOfBusinessAccountNumber()
        {
            return "665433";
        }

        public string GetReceiptCode()
        {
            return "98878";
        }

        public static int Count; 

        public string GenerateReceiptNumber(long receiptId)
        {
            //var date = DateTime.Now.ToString(("yyyy’-‘MM’-‘dd’"));
            var year = DateTime.Now.ToString(("yyyy"));
            var month = DateTime.Now.ToString(("MM"));
            var day = DateTime.Now.ToString(("dd"));

            var sb = new StringBuilder();
            sb.Append(year + month + day + receiptId.ToString());
            var ReceiptNumber = sb.ToString();
            return ReceiptNumber;                         
        }

        public string GenerateCVSFileName()
        {
            var year = DateTime.Now.ToString(("yyyy"));
            var month = DateTime.Now.ToString(("MM"));
            var day = DateTime.Now.ToString(("dd"));

            var sb = new StringBuilder();
            sb.Append(year + month + day + "BatchFile");
            var fileName = sb.ToString();
            return fileName;
        }

        [HttpGet]
        public string GenerateCVSFileNameAJAX()
        {
            var year = DateTime.Now.ToString(("yyyy"));
            var month = DateTime.Now.ToString(("MM"));
            var day = DateTime.Now.ToString(("dd"));

            var sb = new StringBuilder();
            sb.Append(year + month + day + "BatchFile");
            var fileName = sb.ToString();
            return fileName + ".csv";
        }

        public string GenerateTransactionDescription (string ReceiptNumber , string Customer , string CUSTID)
        {
            var sb = new StringBuilder();
            var details = sb.Append("REC#" + ReceiptNumber + "-" + Customer + "-"  + CUSTID );
            return details.ToString(); 
        }


        // GET: Receipts/Edit/5
        public ActionResult Edit(int? id)
        {

            var paymentTypes = db.PaymentType.ToList();
            if (paymentTypes != null)
            {
                viewModel.AllPaymentTypes = paymentTypes;
            }

            var allDocumentTypes = db.DocumentType.ToList();
            if (allDocumentTypes != null)
            {
                viewModel.AllDocumentTypes = allDocumentTypes;
            }

            var receiptTypeCategories = db.ReceiptTypeCategory.ToList();
            if (receiptTypeCategories != null)
            {
                viewModel.AllReceiptTypeCategories = receiptTypeCategories;
            }


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = db.Receipt.Find(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            viewModel.Receipt = receipt;
            ViewBag.DocumentTypeID = new SelectList(db.DocumentType, "DocumentTypeID", "Description", receipt.DocumentTypeID);
            //return View(receipt);
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection form)
        {

            //dont forget to remove parameter 
            Receipt receipt = new Receipt();
            //receipt.ReceiptID = Convert.ToInt64(GenerateId());
            //viewModel.ReceiptTypeCategories = Convert.ToInt32(Request.Form["Receipt.ReceiptID"]);
            receipt.Date = Convert.ToDateTime(Request.Form["Receipt.Date"]);
            receipt.AdditionalInfo = Convert.ToString(Request.Form["Receipt.AdditionalInfo"]);
            receipt.BankAccountNumber = Convert.ToInt32(Request.Form["Receipt.BankAccountNumber"]);
            receipt.IncomeAccountNumber = Convert.ToInt32(Request.Form["Receipt.IncomeAccountNumber"]);
            receipt.LineOfBusinessAccountNumber = Convert.ToString(Request.Form["Receipt.LineOfBusinessAccountNumber"]);
            receipt.ReceiptCode = Convert.ToInt32(Request.Form["Receipt.ReceiptCode"]);
            receipt.ReceivedFrom = Convert.ToString(Request.Form["Receipt.ReceivedFrom"]);
            receipt.TotalAmount = Convert.ToDecimal(Request.Form["Receipt.TotalAmount"]);
            receipt.PaymentTypeID = Convert.ToInt32(Request.Form["Receipt.PaymentTypeID"]);
            receipt.DocumentTypeID = Convert.ToInt32(Request.Form["Receipt.DocumentTypeID"]);

            var services = form["ServiceID"].Split(',');

            ReceiptItem[] items = new ReceiptItem[services.Length];

            List<ReceiptItem> ReceiptItems = new List<ReceiptItem>();


            for (int i = 0; i < services.Length; i++)
            {
                items[i] = new ReceiptItem
                {
                    ReceiptID = receipt.ReceiptID,
                    ServiceID = Convert.ToInt32(services[i])
                };

                ReceiptItems.Add(items[i]);
            }

            if (ModelState.IsValid)
            {
                db.Entry(receipt).State = EntityState.Modified;
                //db.Entry(ReceiptItems).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.DocumentTypeID = new SelectList(db.DocumentType, "DocumentTypeID", "Description", receipt.DocumentTypeID);
            return View(receipt);
        }

        // GET: Receipts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = db.Receipt.Find(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            return View(receipt);
        }

        // POST: Receipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Receipt receipt = db.Receipt.Find(id);
            db.Receipt.Remove(receipt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public JsonResult GetServices(string ReceiptTypeID)
        {
            var id = int.Parse(ReceiptTypeID);
            List<Service> services = new List<Service>();
            services = db.Service.Where(s => s.RecieptTypeID == id).ToList();
            SelectList servicesForcategory = new SelectList(services, "ServiceID", "Description");

            return Json(services, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetAmountForService2(string serviceID)
        {
            var id = int.Parse(serviceID);
            var service = db.Service.Find(id);
            if (service.GCT == true)
            {
                var adjusted = service.Cost;
                service.Cost = CalculateGCTTotal(adjusted);
            }
            return Json(service, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetAmountForService(string serviceID)
        {
            var id = int.Parse(serviceID);
            var service = db.Service.Where(s => s.ServiceID == id);
            return Json(service, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GetAdditionalAmountForChaeuffeurService(string additionalHours)
        {
            var service = db.Service.Where(s => s.ServiceID == 16);

            Service serviceUpdated = new Service();

            foreach(var i in service)
            {

                serviceUpdated.Cost = i.Cost;
                serviceUpdated.Description = i.Description;
                serviceUpdated.ServiceID = i.ServiceID;
                serviceUpdated.RecieptTypeID = i.RecieptTypeID;

            }

            if (Convert.ToInt32(additionalHours) == 0)
            {
                return Json(serviceUpdated, JsonRequestBehavior.AllowGet);
            }

            else
            {
                var add = 1165;
                var additionalAmount = serviceUpdated.Cost + (Convert.ToInt32(additionalHours) * add);
                serviceUpdated.Cost = additionalAmount;
                return Json(serviceUpdated, JsonRequestBehavior.AllowGet);
            }

        }


        [HttpPost]
        public JsonResult GetAdditionalAmountForWhiteGloveService(string additionalHours)
        {
            var service = db.Service.Where(s => s.ServiceID == 18);

            Service serviceUpdated = new Service();

            foreach (var i in service)
            {

                serviceUpdated.Cost = i.Cost;
                serviceUpdated.Description = i.Description;
                serviceUpdated.ServiceID = i.ServiceID;
                serviceUpdated.RecieptTypeID = i.RecieptTypeID;

            }

            if (Convert.ToInt32(additionalHours) == 0)
            {
                return Json(serviceUpdated, JsonRequestBehavior.AllowGet);
            }

            else
            {
                decimal add = 11.65m;
                var additionalAmount = serviceUpdated.Cost + (Convert.ToInt32(additionalHours) * add);
                serviceUpdated.Cost = additionalAmount;
                return Json(serviceUpdated, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public JsonResult CalculateGCTHttp(decimal amount)
        {
        
            decimal gct = 0.15m;

            var d = amount;

            decimal adjusted = d * gct;

            
            return Json(adjusted, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetAdditionalAmountForNormalValetService(string additionalKilometeres)
        {

            var service = db.Service.Where(s => s.ServiceID == 188);
            Service serviceUpdated = new Service();

            foreach (var i in service)
            {

                serviceUpdated.Cost = i.Cost;
                serviceUpdated.Description = i.Description;
                serviceUpdated.ServiceID = i.ServiceID;
                serviceUpdated.RecieptTypeID = i.RecieptTypeID;

            }

            if(Convert.ToInt32(additionalKilometeres) == 0 )
            {
                return Json(serviceUpdated, JsonRequestBehavior.AllowGet);
            }

            else
            {
                var add = 200;
                decimal addKM = (Convert.ToInt32(additionalKilometeres) / 25);
                var km = Math.Round(addKM);
                var additionalAmount = serviceUpdated.Cost + (Convert.ToInt32(km) * add);
                serviceUpdated.Cost = additionalAmount;
                return Json(serviceUpdated, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public ICollection<ReceiptItem> GetReceiptItems(string ReceiptID)
        {
            var id = int.Parse(ReceiptID);
            List<ReceiptItem> itemsOnReceipt = new List<ReceiptItem>();
            itemsOnReceipt = db.ReceiptItem.Where(s => s.ReceiptID == id).ToList();

            return itemsOnReceipt;
        }

        public static  List<string> ServicesFromView = new List<string>();

        [HttpPost]
        public void PushServiceId(IEnumerable<string> services)
        {
            foreach(var i in services)
            {

                ServicesFromView.Add(i);

            }

        }

        public static List<string> AmountsFromView = new List<string>();

        [HttpPost]
        public void PushAmount(IEnumerable<string> amounts)
        {
            foreach (var i in amounts)
            {
                AmountsFromView.Add(i);
            }

        }

        public static int currencyIDFromView = new int();

        [HttpPost]
        public void PushCurrencyId(string currencyID)
        {
            currencyIDFromView = Convert.ToInt32(currencyID); 

        }

        public static List<string> QuantitiesFromView = new List<string>();

        [HttpPost]
        public void PushQuantities(IEnumerable<string> quantities)
        {
            foreach (var i in quantities)
            {
                QuantitiesFromView.Add(i);
            }

        }

        public static List<string> AdditionalInfoFromView = new List<string>();

        [HttpPost]
        public void PushAdditionalInfo(IEnumerable<string> AdditionalInformation)
        {
            foreach (var i in AdditionalInformation)
            {
                AdditionalInfoFromView.Add(i);
            }
        }




        [HttpPost]
        public void GenerateCSVBatchPost(string startDate, string endDate)
        {

            var fileName = GenerateCVSFileName();
            string subfoldername = "CVSFile";
            string filename = fileName;

            string p = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, subfoldername, filename);

            var path = p + ".csv";

            using (var stream = System.IO.File.Create(path)) ;

            var accountNumbers = db.BankCode.DistinctBy(c => c.BankCodeNumber).ToList();

            //var list = accountNumbers.Select(x => x.BankCodeNumber).Distinct().ToList();

            foreach (var i in accountNumbers)
            {

                var header = RetrieveBatchHeader(Convert.ToDateTime(startDate).AddHours(00).AddMinutes(00).AddSeconds(00), Convert.ToDateTime(endDate).AddHours(23).AddMinutes(59).AddSeconds(59), Convert.ToString(i.BankCodeNumber));

                var records = RetrieveBatchDetails(Convert.ToDateTime(startDate).AddHours(00).AddMinutes(00).AddSeconds(00), Convert.ToDateTime(endDate).AddHours(23).AddMinutes(59).AddSeconds(59), Convert.ToString(i.BankCodeNumber));

                using (var stream = System.IO.File.Open(path, FileMode.Append))
                using (var writer = new StreamWriter(stream))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    //// Don't write the header again.
                    csv.Configuration.HasHeaderRecord = true;
                    if (header.Count > 0)
                    {
                        csv.Configuration.HasHeaderRecord = true;
                        csv.WriteRecords(header);
                    }


                }
                using (var stream = System.IO.File.Open(path, FileMode.Append))
                using (var writer = new StreamWriter(stream))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    if (records.Count > 0)
                    {
                        csv.Configuration.HasHeaderRecord = true;
                        csv.WriteRecords(records);

                    }

                }

            }

            DownloadFile();

        }



        [HttpPost]
        public JsonResult ExportCSV()
        {
            var fileName = GenerateCVSFileName();

            string sub = "CVSFile";

            string filename = fileName + ".csv";

            string p = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, sub,  filename);

            var path = p + ".csv";

            //return the Excel file name
            return Json(new { fileName = filename, errorMessage = "" });
        }


        public FileResult DownloadFile()
        {

            var f = GenerateCVSFileName();

            string fileName = f + ".csv";

            //Build the File Path.
            string path = Server.MapPath("~/CVSFile/") + fileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }

        [HttpGet]
        public FileResult DownloadFile2()
        {

            var f = GenerateCVSFileName();

            string fileName = f + ".csv";

            //Build the File Path.
            string path = Server.MapPath("~/CVSFile/") + fileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }

        [HttpPost]
        public void Email(string receiptId , string receiptTypeId , string email)
        {
            var id = Convert.ToInt32(receiptId);
            var r = db.Receipt.Where(r => r.ReceiptID == id);

            Receipt receipt = new Receipt();

            foreach(var i in r)
            {
                receipt.ReceiptID = i.ReceiptID;
                receipt.PaymentTypeID = i.PaymentTypeID;
                receipt.IncomeAccountNumber = i.IncomeAccountNumber;
                receipt.LastFourDigits = i.LastFourDigits;
                receipt.ReceiptCode = i.ReceiptCode;
                receipt.ReceiptItems = i.ReceiptItems;
                receipt.ReceivedFrom = i.ReceivedFrom;
                receipt.TotalAmount = i.TotalAmount;
                receipt.ReceiptNumber = i.ReceiptNumber;
                receipt.AdditionalInfo = i.AdditionalInfo;
                receipt.BankAccountNumber = i.BankAccountNumber;
                receipt.ChequeNumber = i.ChequeNumber;
                receipt.CooperateClient = i.CooperateClient;
                receipt.Date = i.Date;
                receipt.DocumentType = i.DocumentType;
                receipt.LineOfBusinessAccountNumber = i.LineOfBusinessAccountNumber;    
                

            }

            //new InvoicerApi(SizeOption.A4, OrientationOption.Landscape, "$")
            //    .TextColor("#000000")
            //    .BackColor("#ffff30")
            //    .Image(@"..\..\images\vodafone.jpg", 125, 27)
            //    .Company(Address.Make("Received From", new string[] { receipt.ReceivedFrom }, "1471587", "569953277"))
            //    .Client(Address.Make("BILLING TO", new string[] { "" }))
            //    .Items(
            //    new List<ItemRow> {

            //        ItemRow.Make("Nexus 6", "Midnight Blue", (decimal)1, 20, (decimal)166.66, (decimal)199.99),
            //        ItemRow.Make("24 Months (£22.50pm)", "100 minutes, Unlimited texts, 100 MB data 3G plan with 3GB of UK Wi-Fi", (decimal)1, 20, (decimal)360.00, (decimal)432.00),
            //        ItemRow.Make("Special Offer", "Free case (blue)", (decimal)1, 0, (decimal)0, (decimal)0),
            //    })
            //    .Totals(new List<TotalRow> {
            //        TotalRow.Make("Sub Total", (decimal)526.66),
            //        TotalRow.Make("VAT @ 20%", (decimal)105.33),
            //        TotalRow.Make("Total", (decimal)631.99, true),
            //    })
            //    .Details(new List<DetailRow> {
            //        DetailRow.Make("PAYMENT INFORMATION", "Make all cheques payable to Vodafone UK Limited.", "", "If you have any questions concerning this invoice, contact our sales department at sales@vodafone.co.uk.", "", "Thank you for your business.")
            //    })
            //    .Footer("http://www.vodafone.co.uk")
            //    .Save();


           if (Convert.ToInt32(receiptTypeId) == 40 || Convert.ToInt32(receiptTypeId) == 6)
            //if (Convert.ToInt32(receiptTypeId) == 6)
            {
                CreatePdfInvoice(receipt , email);
            }
            else if (Convert.ToInt32(receiptTypeId) == 3)
            {
                CreatePdfAssetDisposal(receipt , email);
            }
            else
            {
                CreatePdfNormal(receipt , email);
            }

        }


        public void CreatePdfNormal(Receipt receipt , string email)
        {
            //AppDomain.CurrentDomain.BaseDirectory will give you the root folder
            //Here you need to provide the subfoldername where your file exists
            //You need to change this as per your design
            string subfoldername = "images";
            //Your fileName
            string filename = "JAA-New-logo-copy-web-black-1.png";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, subfoldername, filename);

            var pdf = new InvoicerApi(SizeOption.A4, OrientationOption.Landscape, "$");
            pdf.BillingDate(receipt.Date);
            pdf.Reference(receipt.ReceiptNumber);
            
            string[] addresslines = {  };
            Address add = new Address
            {
                Title = "Jamaica Automobile Association",
                CompanyNumber = "",
                VatNumber = "",
                AddressLines = addresslines

                
            };

            var image =  Properties.Resource1.JAA_New_logo_copy_web_black_1;
    

           
            pdf.Company(add);
            pdf.TextColor("#000000");
            pdf.BackColor("#ffffff");

            //pdf.Image(@"C:\Users\Jomo\source\repos\JAAReceipts\JAAReceipts.WebApp\images\JAA-New-logo-copy-web-black-1.png", 125, 27);
            pdf.Image(path, 125, 27);
            pdf.Company(Address.Make("Received From", new string[] { receipt.ReceivedFrom }, "1471587", "569953277"));
            pdf.Client(Address.Make("", new string[] { "" }));

            List<ItemRow> items = new List<ItemRow>();
            List<DetailRow> detailRows = new List<DetailRow>();
            detailRows.Add(DetailRow.Make("Additional Info"));
            //pdf.Details(detailRows);

            foreach (var i in receipt.ReceiptItems)
            {
                items.Add(ItemRow.Make(i.Service.Description, " ", (decimal)i.Quantity, 0, i.Service.Cost, (decimal)i.Amount , (decimal)i.GCT ));
            }
            pdf.Items(items);

            

            List<TotalRow> totalRows = new List<TotalRow>();
            totalRows.Add(TotalRow.Make("Total Amount", receipt.TotalAmount));
            pdf.Totals(totalRows);
            pdf.Footer("https://www.calljaa.com/");
            pdf.SaveAndEmail( email , "JAAPDF");
        }

        public void CreatePdfInvoice(Receipt receipt, string email)
        {


            //AppDomain.CurrentDomain.BaseDirectory will give you the root folder
            //Here you need to provide the subfoldername where your file exists
            //You need to change this as per your design
            string subfoldername = "images";
            //Your fileName
            string filename = "JAA-New-logo-copy-web-black-1.png";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, subfoldername, filename);

            var pdf = new InvoicerApi("Invoice" ,SizeOption.A4, OrientationOption.Landscape , "$");
            pdf.BillingDate(receipt.Date);
            pdf.Reference(receipt.ReceiptNumber);
            string[] addresslines = {  };
            Address add = new Address
            {
                Title = "Jamaica Automobile Association",
                CompanyNumber = "",
                VatNumber = "",
                AddressLines = addresslines
       
            };

            pdf.Company(add);
            pdf.TextColor("#000000");
            pdf.BackColor("#ffffff");
            //pdf.Image(@"C:\Users\Jomo\source\repos\JAAReceipts\JAAReceipts.WebApp\images\JAA-New-logo-copy-web-black-1.png", 125, 27);
            pdf.Image(path, 125, 27);
            pdf.Company(Address.Make("Received From", new string[] { receipt.ReceivedFrom }, "1471587", "569953277"));
            pdf.Client(Address.Make("", new string[] { "" }));

            List<ItemRow> items = new List<ItemRow>();
            List<DetailRow> detailRows = new List<DetailRow>();
            detailRows.Add(DetailRow.Make("Additional Info"));
            //pdf.Details(detailRows);

            foreach (var i in receipt.ReceiptItems)
            {
                items.Add(ItemRow.Make( "Invoice: " + i.AdditionalInformation, "", 1, 0, i.Service.Cost, (decimal)i.Amount));
            }
            pdf.Items(items);

            

            List<TotalRow> totalRows = new List<TotalRow>();
            totalRows.Add(TotalRow.Make("Total Amount", receipt.TotalAmount));
            pdf.Totals(totalRows);
            pdf.Footer("https://www.calljaa.com/");
            pdf.SaveAndEmail(email, "JAAPDF");
        }

        public void CreatePdfAssetDisposal(Receipt receipt, string email)
        {


            //AppDomain.CurrentDomain.BaseDirectory will give you the root folder
            //Here you need to provide the subfoldername where your file exists
            //You need to change this as per your design
            string subfoldername = "images";
            //Your fileName
            string filename = "JAA-New-logo-copy-web-black-1.png";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, subfoldername, filename);


            var pdf = new InvoicerApi("AssetDisposal",SizeOption.A4, OrientationOption.Landscape, "$");
            pdf.TextColor("#000000");
            pdf.BackColor("#ffffff");
            //pdf.Image(@"C:\Users\Jomo\source\repos\JAAReceipts\JAAReceipts.WebApp\images\JAA-New-logo-copy-web-black-1.png", 125, 27);
            pdf.Image(path, 125, 27);
            pdf.Company(Address.Make("Received From", new string[] { receipt.ReceivedFrom }, "1471587", "569953277"));
            pdf.Client(Address.Make("", new string[] { "" }));

            List<ItemRow> items = new List<ItemRow>();
            List<DetailRow> detailRows = new List<DetailRow>();
            detailRows.Add(DetailRow.Make("Additional Info"));

            foreach (var i in receipt.ReceiptItems)
            {
                items.Add(ItemRow.Make(i.AdditionalInformation, i.Service.Description, (decimal)1, 0, (decimal)i.Amount, (decimal)i.Amount));
            }
            pdf.Items(items);

            List<TotalRow> totalRows = new List<TotalRow>();
            totalRows.Add(TotalRow.Make("Total Amount", receipt.TotalAmount));
            pdf.Totals(totalRows);
            pdf.Footer("https://www.calljaa.com/");
            pdf.SaveAndEmail(email, "JAAPDF");
        }

    }
}
