using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace JAAReceipts.WebApp.Models
{
    public class BankCode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BankCodeID { get; set; }

        public int PaymentTypeID { get; set; }

        public long BankCodeNumber { get; set; }
    }
}