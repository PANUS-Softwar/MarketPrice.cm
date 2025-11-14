using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPrice.Models
{
    internal class VerificationType
    {
        public Guid VerificationTypeId { get; set; }
        public required VerificationTypeNames VerificationTypeName { get; set; }


        public enum VerificationTypeNames
        {
            PhoneNumber,
            EmailAddress,
            IdCardNumber
        }
    }
}
