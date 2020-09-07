using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JAAReceipts.Web.Models
{
    public class ReceiptType
    {
        [Key]
        public int ReceiptTypeID { get; set; }

        public ReceiptTypeCategory ReceiptTypeCategory { get; set; }

        public int RecieptTypeCategoryID { get; set; }

        public string Description { get; set; }


    }
}
