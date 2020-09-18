using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JAAReceipts.WebApp.Models
{
    public class ReceiptType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReceiptTypeID { get; set; }

        public ReceiptTypeCategory ReceiptTypeCategory { get; set; }

        public int RecieptTypeCategoryID { get; set; }

        public string Description { get; set; }


    }
}
