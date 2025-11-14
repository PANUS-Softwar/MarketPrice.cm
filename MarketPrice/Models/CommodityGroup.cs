using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPrice.Models
{
    internal class CommodityGroup
    {
        public Guid CommodityGroupId { get; set; }
        public required CommodityGroupNames CommodityGroupName { get; set; }

        public enum CommodityGroupNames
        {
            Grain,
            Bulb,
            Nut,
            Oil,
            Tubers
        }
    }
}
