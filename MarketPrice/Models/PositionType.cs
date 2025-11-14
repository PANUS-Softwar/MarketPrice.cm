using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPrice.Models
{
    internal class PositionType
    {
        public byte PositionTypeId { get; set; }

        [StringLength(15)]
        public required PositionTypeNames PositionTypeName { get; set; }

        public enum PositionTypeNames
        {
            Bid,
            Offer
        }
    }
}
