using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JAAReceipts.WebApp.Models
{
    public class CooperateClients
    {
        [Key]
        public int CooperateClientID { get; set; }

        public string Description { get; set; }
    }
}