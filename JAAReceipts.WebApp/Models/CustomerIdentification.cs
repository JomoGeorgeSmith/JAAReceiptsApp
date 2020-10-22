using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAAReceipts.WebApp.Models
{
    public class CustomerIdentification
    {
        public int CustomerIdentificationID { get; set; }

        public ReceiptTypeCategory ReceiptTypeCategory { get; set; }

        public int ReceiptTypeCategoryID { get; set; }

        public string CUSTID { get; set; }
    }
}