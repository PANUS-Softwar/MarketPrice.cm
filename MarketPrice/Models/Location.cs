using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPrice.Models
{
    internal class Location
    {
        public Guid LocationId { get; set; }
        public byte LocationTypeId { get; set; }
        public Guid UserId { get; set; }
        public required Regions Region { get; set; }
        public string? Street { get; set; }
        public required string Town { get; set; }
        public required string Quarter { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }

        public enum Regions
        {
            West,
            Southwest,
            Northwest,
            South,
            East,
            Littoral,
            Center,
            Adamawa,
            North,
            FarNorth
        }
    }   
}
