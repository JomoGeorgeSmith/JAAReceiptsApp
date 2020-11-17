using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAAReceipts.WebApp.Models
{
    public class BatchHeader
    {
        public string Batch { get; set; }

        public string BatchNumber { get; set; }

        public string PeriodToPost { get; set; }

        public string ReconciliationMode { get; set; }

        public DateTime BatchDate { get; set; }

        public string BatchHandeling { get; set; }

        public decimal ControlTotal { get; set; }

        public string BankAccount { get; set; }

        public string BankSubAccount { get; set; }
    }
}