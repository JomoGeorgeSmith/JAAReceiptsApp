using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace JAAReceipts.WebApp.Models
{
    public class ReceiptItem
    {
        [Key]
        public int RecieptItemID { get; set; }

        public virtual Receipt Receipt { get; set; }

        public long ReceiptID { get; set; }

        public virtual Service Service { get; set; }

        public int ServiceID { get; set; }

#nullable enable

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal? Amount { get; set; }
        public int? Quantity { get; set; }
        public string? AdditionalInformation { get; set; }
#nullable disable
    }
}