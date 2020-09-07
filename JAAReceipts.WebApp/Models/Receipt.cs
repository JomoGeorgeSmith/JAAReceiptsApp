using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace JAAReceipts.WebApp.Models
{
    public class Receipt
    {
        [Key]
        public long ReceiptID { get; set; }

        public Guid ReceiptNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Payment Type")]

        public virtual PaymentType PaymentType { get; set; }

        public int PaymentTypeID { get; set; }

        [Display(Name = "Total Amount")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Bank Account Number")]
        public long BankAccountNumber { get; set; }

        [Display(Name = "Income Account Number")]
        public long IncomeAccountNumber { get; set; }

        [Display(Name = "Line Of Business Account Number")]
        public string LineOfBusinessAccountNumber { get; set; }

        public int DocumentTypeID  { get; set; }

        public DocumentType DocumentType { get; set; }

        [Display(Name = "Receipt Code")]
        public long  ReceiptCode { get; set; }

        [Display(Name = "Recieved From ")]
        public string ReceivedFrom { get; set; }

#nullable enable
        [Display(Name = "Additional Information")]
        public string? AdditionalInfo { get; set; }

        public long ChequeNumber { get; set; }

        public int LastFourDigits { get; set; }

#nullable disable

        public virtual ICollection<ReceiptItem> ReceiptItems { get; set; }

        //public int ReceiptItemsID { get; set; }


    }
}
