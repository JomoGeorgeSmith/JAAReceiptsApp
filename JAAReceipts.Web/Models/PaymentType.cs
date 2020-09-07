﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace JAAReceipts.Web.Models
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeID { get; set; }

        public string Description { get; set; }
    }
}