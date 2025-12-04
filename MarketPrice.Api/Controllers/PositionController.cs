using Microsoft.AspNetCore.Mvc;
using MarketPrice.Data;
using Microsoft.EntityFrameworkCore;
using MarketPrice.Models;

namespace MarketPrice.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PositionController : ControllerBase
    {
        private readonly MarketPriceDbContext _context;

        public PositionController(MarketPriceDbContext context)
        {
            _context = context;
        }

        // URL: POST /Position
        [HttpPost]
        public async Task<IActionResult> CreatePosition([FromBody] Position newPosition)
        {
            // --- A. VALIDATION ---

            // 1. SKIP USER CHECK (As requested)
            // We comment this out so the API doesn't stop you.
            // However, the Database might still stop you if "Foreign Keys" are active.
            /* var userExists = await _context.Users.AnyAsync(u => u.UserId == newPosition.UserId);
            if (!userExists)
            {
                return BadRequest("Error: The User ID provided does not exist.");
            }
            */

            // 2. Check Commodity (We keep this because Commodities usually exist from seeding)
            var commodityExists = await _context.Commodities.AnyAsync(c => c.CommodityId == newPosition.CommodityId);
            if (!commodityExists)
            {
                return BadRequest("Error: The Commodity ID provided does not exist.");
            }

            // --- B. SERVER LOGIC ---
            newPosition.PositionId = Guid.NewGuid();
            newPosition.Date = DateTime.Now;

            if (newPosition.CurrentStatusId == 0)
                newPosition.CurrentStatusId = 5001;

            // --- C. SAVING ---
            _context.Positions.Add(newPosition);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // If the database rejects the fake User ID, this block runs.
                return BadRequest($"Database Rejected the User ID: {newPosition.UserId}. The database requires a valid User. Details: {ex.InnerException?.Message}");
            }

            // --- D. RESPONSE ---
            return CreatedAtAction(nameof(GetPositionById), new { id = newPosition.PositionId }, newPosition);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Position>> GetPositionById(Guid id)
        {
            var position = await _context.Positions.FindAsync(id);
            if (position == null) return NotFound();
            return position;
        }
    }
}