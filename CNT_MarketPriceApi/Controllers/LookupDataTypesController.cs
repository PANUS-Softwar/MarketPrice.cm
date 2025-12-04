using MarketPrice.Data;
using MarketPrice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CNT_MarketPriceApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LookupDataTypesController(MarketPriceDbContext context) : ControllerBase
    {

        private readonly MarketPriceDbContext _context = context;

        [HttpGet]
        public ActionResult<IEnumerable<LookupDataType>> Get()
        {
            return _context.LookupDataTypes;
        }

        [HttpGet("{id}")]
        public ActionResult<LookupDataType> Get(int id)
        {
            var lookupDataType = _context.LookupDataTypes.SingleOrDefault(ldt => ldt.LookupDataTypeId == id);

            if (lookupDataType is null)
            {
                return NotFound($"The lookup data type with id: {id} was not found.");
            }

            return lookupDataType;
        }

        [HttpPost]
        public ActionResult Post(LookupDataType lookupDataType)
        {
            if (lookupDataType.LookupDataTypeId <= 0)
            {
                return BadRequest("The Id should be a positive integer.");
            }

            var idExists = _context.LookupDataTypes.Any(ldt => ldt.LookupDataTypeId == lookupDataType.LookupDataTypeId);
            var nameExists = _context.LookupDataTypes.Any(ldt => ldt.LookupDataTypeName == lookupDataType.LookupDataTypeName);

            if (!idExists && !nameExists)
            {
                _context.LookupDataTypes.Add(lookupDataType);
                _context.SaveChanges();

                return CreatedAtAction(nameof(Get), new { id = lookupDataType.LookupDataTypeId }, $"New item created with Id: {lookupDataType.LookupDataTypeId}");
            }

            if (idExists && !nameExists)
            {
                return Conflict($"Lookup data type with Id {lookupDataType.LookupDataTypeId} already exists.");
            }

            if (!idExists && nameExists)
            {
                return Conflict($"Lookup data type with name '{lookupDataType.LookupDataTypeName}' already exists.");
            }

            return Conflict("The item already exists.");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var targetLookupDataType = _context.LookupDataTypes.SingleOrDefault(ldt => ldt.LookupDataTypeId == id);

            if (targetLookupDataType is null)
            {
                return NotFound("Item does not exist. Cannot delete non-existent item.");
            }

            _context.LookupDataTypes.Remove(targetLookupDataType);
            _context.SaveChanges();

            return Ok($"Lookup data type with Id: {id} deleted successfully.");
        }

        [HttpPut]
        public ActionResult Put(LookupDataType lookupDataType)
        {
            var targetLookupDataType = _context.LookupDataTypes.SingleOrDefault(ltd => ltd.LookupDataTypeId == lookupDataType.LookupDataTypeId);

            if (targetLookupDataType is null)
            {
                _context.LookupDataTypes.Add(lookupDataType);
                _context.SaveChanges();

                return Ok("New item created.");
            }

            // Update mutable fields only
            targetLookupDataType.LookupDataTypeName = lookupDataType.LookupDataTypeName;
            _context.SaveChanges();

            return Ok("Item updated successfully.");
        }
    }
}