using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPrice.Models
{
    internal class Rating
    {
        public Guid RatingId { get; set; }
        public Guid RaterUserId { get; set; }
        public Guid RatedUserId { get; set; }
        public required byte Score { get; set; }
        public string? Comment { get; set; }
        public required DateTime DateSubmitted { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
