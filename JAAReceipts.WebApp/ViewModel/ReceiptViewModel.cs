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

        public Receipt Receipt { get; set; }

        public List<DocumentType> AllDocumentTypes { get; set; }
    }
}