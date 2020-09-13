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

//using JAAReceipts.WebApp.Migrations;

namespace JAAReceipts.WebApp.Views
{
    public class ReceiptsController : Controller
    {
        private JAAReceiptsContext db = new JAAReceiptsContext();
        ReceiptViewModel viewModel = new ReceiptViewModel();
        public Guid currentReceiptNumber = new Guid();
        public DateTime currentDateTime = new DateTime();

        public ActionResult ReceiptsViewModel()
        {
            ReceiptViewModel viewModel = new ReceiptViewModel();
            var receiptTypeCategories = db.ReceiptTypeCategory.ToList();
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
            if(items != null)
            {
                ViewBag.data = items;
            }

            return View();
        }

        // GET: Receipts
        public ActionResult Index()
        {
            var receipt = db.Receipt.Include(r => r.DocumentType)
                .Include(r => r.ReceiptItems);

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

            // return View(vm.ToList());

            return View(LVM.ToList());

            //count = 0; 
        }

        public string GetServicesOnReceipt(int receiptId)
        {

            var services = (from c in db.Receipt
                       join t in db.ReceiptItem on c.ReceiptID equals t.ReceiptID
                       join s in db.Service on t.ServiceID equals s.ServiceID
                            where c.ReceiptID == receiptId
                            select new { s.Description })
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

            //Initialize services for category
            //var services = db.Service.ToList();
            //if (services != null)
            //{
            //    viewModel.AllServices = services;
            //}

            var paymentTypes = db.PaymentType.ToList();
            if(paymentTypes != null)
            {
                viewModel.AllPaymentTypes = paymentTypes;
            }

          //  viewModel.GUID = NewGUID();

            //var date = new DateTime();
            viewModel.Date = DateTime.Now;

            //currentReceiptNumber = viewModel.GUID;
            //currentDateTime = viewModel.Date;

            return View(viewModel);
        }

        public Guid NewGUID()
        {
            Guid g = Guid.NewGuid();
           // currentReceiptNumber = g;
            return g;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection form)
        {
            //dont forget to remove parameter 
            Receipt receipt = new Receipt();

            //receipt.Date = Convert.ToDateTime(Request.Form["Receipt.Date"]);

            receipt.Date = Convert.ToDateTime(DateTime.Now);
            receipt.AdditionalInfo = Convert.ToString(Request.Form["Receipt.AdditionalInfo"]);
            //receipt.BankAccountNumber = Convert.ToInt32(Request.Form["Receipt.BankAccountNumber"]);
            receipt.BankAccountNumber = Convert.ToInt32(GetBankAccountNumber());
            //receipt.IncomeAccountNumber = Convert.ToInt32(Request.Form["Receipt.IncomeAccountNumber"]);
            receipt.IncomeAccountNumber = Convert.ToInt32(GetIncomeAccountNumber());
            //receipt.LineOfBusinessAccountNumber = Convert.ToString(Request.Form["Receipt.LineOfBusinessAccountNumber"]);
            receipt.LineOfBusinessAccountNumber = Convert.ToString(GetLineOfBusinessAccountNumber());
            //receipt.ReceiptCode = Convert.ToInt32(Request.Form["Receipt.ReceiptCode"]);
            receipt.ReceiptCode = Convert.ToInt32(GetReceiptCode());
            receipt.ReceivedFrom = Convert.ToString(Request.Form["Receipt.ReceivedFrom"]);
            receipt.TotalAmount = Convert.ToDecimal(Request.Form["Receipt.TotalAmount"]);
            receipt.PaymentTypeID = Convert.ToInt32(Request.Form["Receipt.PaymentTypeID"]);
            receipt.DocumentTypeID = Convert.ToInt32(Request.Form["Receipt.DocumentTypeID"]);

            if (receipt.PaymentTypeID == 2 || receipt.PaymentTypeID == 3 || receipt.PaymentTypeID == 4)
            {
                receipt.LastFourDigits = Convert.ToInt32(Request.Form["Receipt.LastFourDigits"]);
   
            }

           
            if(receipt.PaymentTypeID == 7 || receipt.PaymentTypeID == 8 )
            {
                receipt.ChequeNumber = Convert.ToInt32(Request.Form["Receipt.ChequeNumber"]);
            }

            //Invoice
            if (Convert.ToInt32(form["ServiceID"]) == 26)
            {
                receipt.CustomerID = Convert.ToString(Request.Form["Receipt.CustomerID"]);
            }


            //receipt.ReceiptNumber = GenerateReceiptNumber(receipt.ReceiptID);

            //db.SaveChanges();

            //var services = form["ServiceID"].Split(',');

            ReceiptItem[] items = new ReceiptItem[ServicesFromView.Count];

            List<ReceiptItem> ReceiptItems = new List<ReceiptItem>();

            var serv = ServicesFromView.ToArray();

            var amt = AmountsFromView.ToArray();

            var qnt = QuantitiesFromView.ToArray();

            var inf = AdditionalInfoFromView.ToArray();

            bool invoice = false;

            bool assetDisposal = false;

            for (int i = 0; i < ServicesFromView.ToArray().Length; i++)
            {
                if (Convert.ToInt32(serv[i]) == 26 )
                {
                    invoice = true;

                    items[i] = new ReceiptItem
                    {
                        ReceiptID = receipt.ReceiptID,
                        ServiceID = Convert.ToInt32(serv[i]),
                        Amount = Convert.ToDecimal(amt[i]) ,
                        AdditionalInformation = Convert.ToString(inf[i])
                    };
                }

                else if(Convert.ToInt32(serv[i]) == 15)
                {
                    assetDisposal = true; 

                    items[i] = new ReceiptItem
                    {
                        ReceiptID = receipt.ReceiptID,
                        ServiceID = Convert.ToInt32(serv[i]),
                        Amount = Convert.ToDecimal(amt[i]) ,
                        AdditionalInformation = Convert.ToString(inf[i])
                    };

                }

                else
                {
                    items[i] = new ReceiptItem
                    {
                        ReceiptID = receipt.ReceiptID,
                        ServiceID = Convert.ToInt32(serv[i]),
                        Amount = Convert.ToDecimal(amt[i]),
                        Quantity = Convert.ToInt32(qnt[i])

                    };

                }

                ReceiptItems.Add(items[i]);              
            }

            ServicesFromView.Clear();
            AmountsFromView.Clear();
            QuantitiesFromView.Clear();
            AdditionalInfoFromView.Clear();

            if (ModelState.IsValid)
            {
                db.Receipt.Add(receipt);            
                db.ReceiptItem.AddRange(ReceiptItems);
                db.SaveChanges();

                receipt.ReceiptNumber = GenerateReceiptNumber(receipt.ReceiptID);

                db.SaveChanges();

                //return RedirectToAction("Index");   

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

        private long GenerateId()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }

        public string GetBankAccountNumber()
        {
            return "332211";
        }

        public string GetIncomeAccountNumber()
        {
            return "87788";
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
            //var date = DateTime.Now.ToString(("yyyy-MM-dd"));
            //var date = DateTime.Now.ToString(("MM"));

            var year = DateTime.Now.ToString(("yyyy"));
            var month = DateTime.Now.ToString(("MM"));
            var day = DateTime.Now.ToString(("dd"));

            var sb = new StringBuilder();
            sb.Append(year + month + day + receiptId.ToString());
            //sb.Append(date + " - " + receiptId.ToString());
            var ReceiptNumber = sb.ToString();
            return ReceiptNumber;                         
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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ReceiptID,Date,PaymentTypeID,TotalAmount,BankAccountNumber,IncomeAccountNumber,LineOfBusinessAccountNumber,DocumentTypeID,ReceiptCode,ReceivedFrom,AdditionalInfo")] Receipt receipt)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(receipt).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    //ViewBag.DocumentTypeID = new SelectList(db.DocumentType, "DocumentTypeID", "Description", receipt.DocumentTypeID);
        //    return View(receipt);
        //}

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

        //[HttpPost]
        //public JsonResult GetAmountForService([Microsoft.AspNetCore.Mvc.FromBody] string serviceID)
        //{
        //    var id = int.Parse(serviceID);
        //    //Service service = new Service();
        //    var service = db.Service.Where(s => s.ServiceID == id);
        //    //SelectList servicesForcategory = new SelectList(services, "ServiceID", "Description" , "Cost");
        //    return Json(service, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public JsonResult GetAmountForService(string serviceID)
        {
            var id = int.Parse(serviceID);
            //Service service = new Service();
            var service = db.Service.Where(s => s.ServiceID == id);
            //SelectList servicesForcategory = new SelectList(services, "ServiceID", "Description" , "Cost");
            return Json(service, JsonRequestBehavior.AllowGet);
        }

        //[Microsoft.AspNetCore.Mvc.FromBody]

        [HttpPost]
        public ICollection<ReceiptItem> GetReceiptItems(string ReceiptID)
        {
            var id = int.Parse(ReceiptID);
            List<ReceiptItem> itemsOnReceipt = new List<ReceiptItem>();
            itemsOnReceipt = db.ReceiptItem.Where(s => s.ReceiptID == id).ToList();
            //SelectList servicesForcategory = new SelectList(services, "ServiceID", "Description");

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




    }
}
