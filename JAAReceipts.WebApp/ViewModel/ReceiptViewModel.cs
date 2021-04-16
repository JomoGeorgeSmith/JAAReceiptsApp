using JAAReceipts.WebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JAAReceipts.WebApp.ViewModel
{
    public class ReceiptViewModel
    {

        [Required (ErrorMessage ="You have to select a category")]
        public List<ReceiptTypeCategory> AllReceiptTypeCategories { get; set; }

        public ReceiptTypeCategory ReceiptTypeCategories { get; set; }

        //[Required(ErrorMessage = "You have to select a service")]
        public List<Service> AllServices { get; set; }

        public List<Service> ServicesOnReceipt { get; set; }

        [Required(ErrorMessage = "You have to select a service")]
        public Service ServiceID { get; set; }

        public Receipt Receipt { get; set; }

        public IQueryable<Receipt> Receipts { get; set; }

        public List<DocumentType> AllDocumentTypes { get; set; }

        
        [Required(ErrorMessage = "You must select a payment type")]
        public List<PaymentType> AllPaymentTypes { get; set; }

        public String ItemsOnReceipt { get; set; }

        public DateTime Date { get; set; }

        public List<CooperateClients> CoopererateClients { get; set; }



        [Required(ErrorMessage = "You have to select a currency")]
        public List<Currency> Currencies { get; set; }

        public List<ServiceRecord> ServiceRecords { get; set; }

        public List<BankCodeRecord> BankCodeRecords { get; set; }

        public List<GCTRecord> GCTRecords { get; set; }

        public List<ReceiptListing> ReceiptListings { get; set; }


        
    }
}