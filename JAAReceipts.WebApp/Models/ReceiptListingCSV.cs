using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAAReceipts.WebApp.Models
{
    public class ReceiptListingCSV
    {

        public string CATran { get; set; }

        //DocumentType
        public string EntryType { get; set; }

        public string AccountNumber { get; set; }

        public string SubAccount { get; set; }

        public string Description { get; set; }

        public string ReferneceNumber { get; set; }

        public string CustomerID { get; set; }

        public string VendorID { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal DebitAmount { get; set; }

        public decimal CreditAmount { get; set; }

        public string ReconciliationStatus { get; set; }

        public String ClearDate { get; set; }
    }
}