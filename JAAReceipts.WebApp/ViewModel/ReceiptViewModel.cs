using JAAReceipts.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAAReceipts.WebApp.ViewModel
{
    public class ReceiptViewModel
    {
        public List<ReceiptTypeCategory> AllReceiptTypeCategories { get; set; }

        public ReceiptTypeCategory ReceiptTypeCategories { get; set; }

        public List<Service> AllServices { get; set; }

        public List<Service> ServicesOnReceipt { get; set; }
        public Service ServiceID { get; set; }

        public Receipt Receipt { get; set; }

        public IQueryable<Receipt> Receipts { get; set; }

        public List<DocumentType> AllDocumentTypes { get; set; }

        public List<PaymentType> AllPaymentTypes { get; set; }

        public String ItemsOnReceipt { get; set; }

        public DateTime Date { get; set; }

        public List<CooperateClients> CoopererateClients { get; set; }
    }
}