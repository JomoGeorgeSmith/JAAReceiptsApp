using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JAAReceipts.Web.Models
{
   public class Service
    {
        [Key]
        public int ServiceID { get; set; }

        public int RecieptTypeID { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal(18 , 2)")]
        public decimal Cost { get; set; }
    }
}
