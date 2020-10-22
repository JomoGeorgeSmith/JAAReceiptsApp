using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace JAAReceipts.WebApp.Models
{
    public class ReceiptListing
    {
        public int ReceiptListingID { get; set; }

        public string BatchStatus { get; set; }

        [Display(Name = "TP TN")]
        public string DocumentType { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Period Entered")]
        public DateTime PeriodEntered { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Period Posted")]
        public DateTime PeriodPosted{ get; set; }

        public string ReferneceNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; }

        public string CustomerID { get; set; }

        public string AccountNumber { get; set; }

        public string SubAccount { get; set; }

        public string TransactionDetails { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        [UIHint("Currency")]
        public decimal DebitAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        [UIHint("Currency")]
        public decimal  CreditAmount { get; set; }


    }
}