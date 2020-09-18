using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;


namespace JAAReceipts.WebApp.Models
{
    public class CooperateClients
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CooperateClientID { get; set; }

        public string Description { get; set; }
    }
}