using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JAAReceipts.WebApp.Models
{
    public class Currency
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CurrencyID { get; set; }

        public  string Description { get; set; }

        public string  CurrencyCode { get; set; }
    }
}