using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JAAReceipts.WebApp.Models
{
    public class BankCodeRecord
    {
        public int BankCodeRecordID { get; set; }

        [Display(Name = "TP TN")]
        public string DocumentType { get; set; }

        public string ReferneceNumber { get; set; }

        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Transaction Date")]
        [Column(TypeName = "datetime")]
        public DateTime TransactionDate { get; set; }

        public string CustomerID { get; set; }

        public string AccountNumber { get; set; }

        public string SubAccount { get; set; }

        public string TransactionDetails { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        [UIHint("Currency")]
        public decimal Amount { get; set; }

        public string Type { get; set; }
    }
}