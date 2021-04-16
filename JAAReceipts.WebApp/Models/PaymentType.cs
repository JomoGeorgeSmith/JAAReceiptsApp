using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JAAReceipts.WebApp.Models
{
    public class PaymentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        //[Required(ErrorMessage = "You must select a payment type")]
        public int PaymentTypeID { get; set; }

        public string Description { get; set; }
    }
}