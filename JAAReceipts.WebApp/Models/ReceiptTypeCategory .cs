using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JAAReceipts.WebApp.Models
{
    public class ReceiptTypeCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReceiptTypeCategoryID { get; set; }

        public string Description { get; set; }
    }
}
