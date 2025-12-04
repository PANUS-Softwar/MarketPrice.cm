using Microsoft.AspNetCore.Mvc;
using MarketPrice.Data;
using Microsoft.EntityFrameworkCore;
using MarketPrice.Models;

namespace MarketPrice.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatsController : ControllerBase
    {
        private readonly MarketPriceDbContext _context;

        public StatsController(MarketPriceDbContext context)
        {
            _context = context;
        }

        // 1. GET /Stats/counts (Bids vs Asks)
        [HttpGet("counts")]
        public async Task<IActionResult> GetMarketCounts()
        {
            var activeBids = await _context.Positions
                .CountAsync(p => p.PositionTypeId == 6001 && p.CurrentStatusId == 5001);

            var activeAsks = await _context.Positions
                .CountAsync(p => p.PositionTypeId == 6002 && p.CurrentStatusId == 5001);

            return Ok(new { Bids = activeBids, Asks = activeAsks });
        }

        // 2. GET /Stats/recent (Recent Activity)
        [HttpGet("recent")]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetRecentActivity()
        {
            // FIX: Since we can't use .Include(), we use a "Join" query.
            // This is like saying: "Match Position P with Commodity C where the IDs are the same"

            var query = from p in _context.Positions
                        join c in _context.Commodities on p.CommodityId equals c.CommodityId
                        orderby p.Date descending
                        select new
                        {
                            Name = c.CommodityName, // We get the name from the joined table
                            Location = "Market",    // Placeholder: Your Position model doesn't have LocationId, so we use a generic name.
                            Price = p.UnitPrice,
                            Type = p.PositionTypeId == 6001 ? "Bid" : "Ask",
                            Date = p.Date
                        };

            var recentItems = await query.Take(5).ToListAsync();

            return Ok(recentItems);
        }
    }
}