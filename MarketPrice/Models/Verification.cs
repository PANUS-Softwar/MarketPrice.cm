using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPrice.Models
{
    internal class Verification
    {
        public Guid VerificationId { get; set; }
        public required Guid UserId { get; set; }
        public required Guid VerificationTypeId { get; set; }
        public string? Notes { get; set; }
        public required DateTime DateSubmitted { get; set; }
        public required VerificationStatus Status { get; set; }

        public enum VerificationStatus
        {
            Verified,
            Unverified,
            Rejected,
            Redo,
            Pending
        }

    }
}
