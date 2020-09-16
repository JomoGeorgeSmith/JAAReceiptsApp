using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace JAAReceipts.WebApp.Models
{
    public class IncomeAccountListing
    {
        public int IncomeAccountListingID { get; set; }

        public int ServiceID { get; set; }

        public long IncomeAccount { get; set; }

    }
}