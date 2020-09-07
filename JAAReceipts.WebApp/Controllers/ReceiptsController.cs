using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JAAReceipts.WebApp.Data;
using JAAReceipts.WebApp.Models;
using JAAReceipts.WebApp.ViewModel;

namespace JAAReceipts.WebApp.Views
{
    public class ReceiptsController : Controller
    {
        private JAAReceiptsContext db = new JAAReceiptsContext();

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
            var receipt = db.Receipt.Include(r => r.DocumentType);
            return View(receipt.ToList());
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

        // GET: Receipts/Create
        public ActionResult Create()
        {
            //ViewBag.DocumentTypeID = new SelectList(db.DocumentType, "DocumentTypeID", "Description");
            ReceiptViewModel viewModel = new ReceiptViewModel();

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

            var services = db.Service.ToList();
            if (services != null)
            {
                viewModel.AllServices = services;
            }

            return View(viewModel);
        }

        public void populateViewModel()
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

           
        }

        // POST: Receipts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReceiptID,Date,TotalAmount,BankAccountNumber,IncomeAccountNumber,LineOfBusinessAccountNumber,DocumentTypeID,ReceiptCode,ReceivedFrom,AdditionalInfo")] Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                db.Receipt.Add(receipt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.DocumentTypeID = new SelectList(db.DocumentType, "DocumentTypeID", "Description", receipt.DocumentTypeID);
            return View(receipt);
        }

        // GET: Receipts/Edit/5
        public ActionResult Edit(int? id)
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
            //ViewBag.DocumentTypeID = new SelectList(db.DocumentType, "DocumentTypeID", "Description", receipt.DocumentTypeID);
            return View(receipt);
        }

        // POST: Receipts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReceiptID,Date,TotalAmount,BankAccountNumber,IncomeAccountNumber,LineOfBusinessAccountNumber,DocumentTypeID,ReceiptCode,ReceivedFrom,AdditionalInfo")] Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receipt).State = EntityState.Modified;
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
    }
}
