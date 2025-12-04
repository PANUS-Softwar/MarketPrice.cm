using Microsoft.AspNetCore.Mvc;
using MarketPrice.Data;
using Microsoft.EntityFrameworkCore;
using MarketPrice.Models;

namespace MarketPrice.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommodityController : ControllerBase
    {
        private readonly MarketPriceDbContext _context;

        public CommodityController(MarketPriceDbContext context)
        {
            _context = context;
        }

        // GET: /Commodity (See all products)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commodity>>> GetAllCommodities()
        {
            return await _context.Commodities.ToListAsync();
        }

        // POST: /Commodity (Add a new product)
        [HttpPost]
        public async Task<IActionResult> CreateCommodity(Commodity newCommodity)
        {
            // 1. Validation: Ensure we aren't adding a duplicate name
            // (e.g., Don't add "Corn" if "Corn" already exists)
            bool exists = await _context.Commodities.AnyAsync(c => c.CommodityName == newCommodity.CommodityName);
            if (exists)
            {
                return BadRequest($"Error: '{newCommodity.CommodityName}' already exists in the database.");
            }

            // 2. Setup ID
            newCommodity.CommodityId = Guid.NewGuid();

            // 3. Save to Database
            _context.Commodities.Add(newCommodity);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // This usually fails if CommodityTypeId or UnitOfMeasureId are invalid
                return BadRequest($"Database Error: Ensure you have valid CommodityType and UnitOfMeasure IDs. Details: {ex.InnerException?.Message}");
            }

            // 4. Return Success
            return CreatedAtAction(nameof(GetAllCommodities), new { id = newCommodity.CommodityId }, newCommodity);
        }
    }
}