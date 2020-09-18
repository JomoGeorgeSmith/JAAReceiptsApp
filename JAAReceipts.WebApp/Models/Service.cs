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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ServiceID { get; set; }

        public int RecieptTypeID { get; set; }

        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        [UIHint("Currency")]
        public decimal Cost { get; set; }

//#nullable enable

//        public string? Currency { get; set; }

//#nullable disable



    }
}
