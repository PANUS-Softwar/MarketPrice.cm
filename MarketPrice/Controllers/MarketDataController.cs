using LinqToDB;
using MarketPrice.Data;
using MarketPrice.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarketPrice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketDataController(MarketPriceDbContext context) : ControllerBase
    {
        private readonly MarketPriceDbContext _context = context;

        [HttpGet($"Summary")]
        public async Task<ActionResult<MarketSummaryModel>> GetMarketSummary()
        {
            var bidsCount = await _context.Positions.CountAsync(p => p.PositionTypeId == 6001);

            var askCount = await _context.Positions.CountAsync(p => p.PositionTypeId == 6002);

            var summary = new MarketSummaryModel()
            {
                ActiveBidsCount = bidsCount,
                ActiveAsksCount = askCount
            };

            return Ok(summary);
        }

    }
}
