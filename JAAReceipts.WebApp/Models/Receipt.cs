using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using JAAReceipts.WebApp.Utility;

namespace JAAReceipts.WebApp.Models
{
    public class Receipt
    {


        [Key]
        public long ReceiptID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        //[Required(ErrorMessage = "You must select a payment type")]
        //public int PaymentTypeID { get; set; }

        public bool CardPayment { get; set; }

        [Display(Name = "Payment Type")]
        public virtual PaymentType PaymentType { get; set; }

        private int paymentTypeID; // field

        [Required(ErrorMessage = "You must select a payment type")]
        public int PaymentTypeID   // property
        {
            get { return paymentTypeID; }
            set { 
                if(value == 2 || value == 3 || value == 4 || value == 5 || value == 6)
                {
                    CardPayment = true;
                }

                else
                {
                    CardPayment = false;
                }
                
                paymentTypeID = value; }
        }
    


        [Display(Name = "Total Amount")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        //[Required(ErrorMessage = "This field cannot be blank")]
        //[RegularExpression("[^0-9]", ErrorMessage = "Must be numeric")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Income Account Number")]
        public long IncomeAccountNumber { get; set; }

        [Display(Name = "Line Of Business Account Number")]
        public string LineOfBusinessAccountNumber { get; set; }

        public int DocumentTypeID  { get; set; }

        public DocumentType DocumentType { get; set; }

        [Display(Name = "Receipt Code")]
        public long  ReceiptCode { get; set; }

        [Display(Name = "Recieved From")]
        [Required(ErrorMessage = "This field cannot be blank")]
        [MinLength (3 , ErrorMessage = "Needs to be atleast 3 characters long")]
        public string ReceivedFrom { get; set; }


        public Currency Currency { get; set; }



#nullable enable




        //[Required(ErrorMessage = "You have to select a currency")]
        public int? CurrencyID { get; set; }

        [Display(Name = "Additional Information")]
        //[RequiredIf("Service", 15, ErrorMessage = "You must input additional info")]
        public string? AdditionalInfo { get; set; }

        public string? ChequeNumber { get; set; }

        //[RequiredIf("CardPayment", true, ErrorMessage = "You must input the last four digits of the card")]
        //[RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        //[Required(ErrorMessage = "This field cannot be blank")]
        //[Required(ErrorMessage = "Last Four Digits Required")]
        public int? LastFourDigits { get; set; }


        //[RequiredIf("CardPayment", true , ErrorMessage = "You must input the last four digits of the card")]
        ////[RegularExpression("[^0-9]", ErrorMessage = " Four digits Must be numeric")]
        ////[Required(ErrorMessage = "This field cannot be blank")]
        //public int? LastFourDigits { get; set; }



        public string? CustomerID { get; set; }

        public string? ReceiptNumber { get; set; }

        public virtual  CooperateClients? CooperateClient { get; set; }

        public int? CooperateClientID { get; set; }

        [Display(Name = "Bank Account Number")]
        public long? BankAccountNumber { get; set; }

#nullable disable

        public virtual ICollection<ReceiptItem> ReceiptItems { get; set; }

        //public int ReceiptItemsID { get; set; }


    }
}
