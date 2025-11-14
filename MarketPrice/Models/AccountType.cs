using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPrice.Models
{
    internal class AccountType
    {
        public required int AccountTypeId { get; set; }

        [StringLength(3, MinimumLength = 3)]
        public required string AccountTypeCode { get; set; }

        [StringLength(50)]
        public required AccountTypeNames AccountTypeName { get; set; }

        public string? Description { get; set; }
        
        public required DateTime DateCreated { get; set; }


        public enum AccountTypeNames
        {
            Company,
            Personal
        }
    }
}
