using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPrice.Models
{
    internal class CommodityType
    {
        public Guid CommodityTypeId { get; set; }
        public Guid CommodityGroupId { get; set; }
        public Guid DefaultUnitOfMeasureId { get; set; }
        public CommodityTypeNames CommodityTypeName { get; set; }

        public enum CommodityTypeNames
        {
            Onion,
            Beans,
            Corn,
            Egusi,
            Ginger,
            PalmOil
        }
    }
}
