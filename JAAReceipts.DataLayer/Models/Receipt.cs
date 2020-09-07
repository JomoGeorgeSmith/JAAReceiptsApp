using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace JAAReceipts.DataLayer.Models
{
    public class Receipt
    {
        [Key]
        public int ReceiptID { get; set; }

        public DateTime Date { get; set; }

        public virtual PaymentType PaymentType { get; set; }

        public decimal TotalAmount { get; set; }

        public long BankAccountNumber { get; set; }

        public long IncomeAccountNumber { get; set; }

        public string LineOfBusinessAccountNumber { get; set; }

        public int DocumentTypeID  { get; set; }

        public DocumentType DocumentType { get; set; }

        public long  ReceiptCode { get; set; }

        public string ReceivedFrom { get; set; }

#nullable enable
        public string? AdditionalInfo { get; set; }

#nullable disable 

        public virtual ICollection<ReceiptItem> ReceiptItem { get; set; }
    }
}
