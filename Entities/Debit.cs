using DebitService.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace DebitLibrary.API.Entities
{
    public class Debit
    {
        public string AccountIdentifier { get; set; }
        public string SortCode { get; set; }
        public string PaymentReference { get; set; }

        public double TransferAmount { get; set; }

    }
}
