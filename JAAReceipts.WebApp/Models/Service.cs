using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JAAReceipts.WebApp.Models
{
   public class Service
    {
        [Key]
        public int ServiceID { get; set; }

        public int RecieptTypeID { get; set; }

        public string Description { get; set; }

        public decimal Cost { get; set; }
    }
}
