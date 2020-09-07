using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JAAReceipts.DataLayer.Models
{
    public class ReceiptTypeCategory
    {
        [Key]
        public int ReceiptTypeCategoryID { get; set; }

        public string Description { get; set; }
    }
}
