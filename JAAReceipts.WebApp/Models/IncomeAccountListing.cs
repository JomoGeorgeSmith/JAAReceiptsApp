using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;


namespace JAAReceipts.WebApp.Models
{
    public class IncomeAccountListing
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IncomeAccountListingID { get; set; }

        public int ServiceID { get; set; }

        public long IncomeAccountNumber { get; set; }

#nullable enable
        //public virtual CooperateClients? CooperateClient { get; set; }
        //public int? CooperateClientID { get; set; }
#nullable disable

    }
}