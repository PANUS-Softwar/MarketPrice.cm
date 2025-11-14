using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPrice.Models
{
    internal class LocationType
    {
        public byte LocationTypeId { get; set; }
        public required LocationTypeNames LocationTypeName { get; set; }

        public enum LocationTypeNames
        {
            MainAddress,
            OtherAddress
        }
    }
}
