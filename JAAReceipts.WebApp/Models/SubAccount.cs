using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JAAReceipts.WebApp.Models
{
    public class SubAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubAccountID { get; set; }

        //public PaymentType PaymentType { get; set; }

        //public int PaymentTypeID { get; set; }

        //public Service Service { get; set; }

        //public int ServiceID { get; set; }

        public ReceiptTypeCategory ReceiptTypeCategory { get; set; }

        public int ReceiptTypeCategoryId { get; set; }

        [Display(Name = "Sub Account Number")]

        public string SubAccountNumber { get; set; }
    }
}