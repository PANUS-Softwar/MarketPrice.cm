using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPrice.Models
{
    internal class UnitOfMeasure
    {
        public Guid UnitOfMeasureId { get; set; }
        public string UnitOfMeasureNameEnglish { get; set; }
        public string UnitOfMeasureNameFrench { get; set; }
        public string UnitOfMeasureCodeEnglish { get; set; }
        public string UnitOfMeasureCodeFrench { get; set; }
    }

}
