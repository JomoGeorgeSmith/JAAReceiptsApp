using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JAAReceipts.WebApp.Models
{
    public class DocumentType
    {
        [Key]
        public int DocumentTypeID { get; set; }

        public string Description { get; set; }
    }
}
