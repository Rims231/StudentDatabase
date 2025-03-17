using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Payment
    {
        [Key]

        public int  PaymentDetails { get; set; }

        public string CardOwnerName { get; set; } = string.Empty;

        public string CardNumber { get; set; } = string.Empty;

        public string ExpirationDate { get; set; } = string.Empty;

        public string SecurityCode { get; set; } = string.Empty;
    }
}

