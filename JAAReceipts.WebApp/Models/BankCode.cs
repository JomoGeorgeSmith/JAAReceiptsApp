using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAAReceipts.WebApp.Models
{
    public class BankCode
    {
        public int BankCodeID { get; set; }

        public int PaymentTypeID { get; set; }

        public long BankCodeNumber { get; set; }
    }
}