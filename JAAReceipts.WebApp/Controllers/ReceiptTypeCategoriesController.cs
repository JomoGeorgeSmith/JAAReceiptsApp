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

namespace JAAReceipts.WebApp.Views
{
    public class ReceiptTypeCategoriesController : Controller
    {
        private JAAReceiptsContext db = new JAAReceiptsContext();

        // GET: ReceiptTypeCategories
        public ActionResult Index()
        {
            return View(db.ReceiptTypeCategory.ToList());
        }

        // GET: ReceiptTypeCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiptTypeCategory receiptTypeCategory = db.ReceiptTypeCategory.Find(id);
            if (receiptTypeCategory == null)
            {
                return HttpNotFound();
            }
            return View(receiptTypeCategory);
        }

        // GET: ReceiptTypeCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReceiptTypeCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReceiptTypeCategoryID,Description")] ReceiptTypeCategory receiptTypeCategory)
        {
            if (ModelState.IsValid)
            {
                db.ReceiptTypeCategory.Add(receiptTypeCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(receiptTypeCategory);
        }

        // GET: ReceiptTypeCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiptTypeCategory receiptTypeCategory = db.ReceiptTypeCategory.Find(id);
            if (receiptTypeCategory == null)
            {
                return HttpNotFound();
            }
            return View(receiptTypeCategory);
        }

        // POST: ReceiptTypeCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReceiptTypeCategoryID,Description")] ReceiptTypeCategory receiptTypeCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receiptTypeCategory).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(receiptTypeCategory);
        }

        // GET: ReceiptTypeCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiptTypeCategory receiptTypeCategory = db.ReceiptTypeCategory.Find(id);
            if (receiptTypeCategory == null)
            {
                return HttpNotFound();
            }
            return View(receiptTypeCategory);
        }

        // POST: ReceiptTypeCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReceiptTypeCategory receiptTypeCategory = db.ReceiptTypeCategory.Find(id);
            db.ReceiptTypeCategory.Remove(receiptTypeCategory);
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
