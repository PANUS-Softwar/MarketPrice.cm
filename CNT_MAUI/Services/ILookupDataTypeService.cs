using CNT_MAUI.Models.POCOs;
namespace CNT_MAUI.Services;

public interface ILookupDataTypeService
{
    Task<IEnumerable<LookupDataType>> GetLookupDataTypeAsync();

    Task<LookupDataType?> GetLookupDataTypeByIdAsync(int id);
}