using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPrice.Models
{
    internal class Position
    {
        public Guid PositionId { get; set; }
        public Guid UserId { get; set; }
        public Guid CommodityId { get; set; }
        public byte PositionTypeId { get; set; }
        public required decimal UnitPrice { get; set; }
        public required decimal Quantity { get; set; }
        public string? Grade { get; set; }
        public string? Description { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime ExpiryDate { get; set; }
        public required DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public required PositionStatus Status { get; set; }

        public enum PositionStatus
        {
            Opened,
            Closed,
            Canceled
        }

    }







}
