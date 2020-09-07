using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace JAAReceipts.Web.Models
{
    public class ReceiptItem
    {
        [Key]
        public int RecieptItemID { get; set; }

        public int ReceiptID { get; set; }

        public virtual Receipt Receipt { get; set; }

        public int ServiceID { get; set; }
       
        public decimal Amount { get; set; }
    }
}