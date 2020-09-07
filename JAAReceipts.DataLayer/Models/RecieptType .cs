using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JAAReceipts.DataLayer.Models
{
    public class ReceiptType
    {
        [Key]
        public int ReceiptTypeID { get; set; }

        public int RecieptTypeCategoryID { get; set; }

        public string Description { get; set; }


    }
}
