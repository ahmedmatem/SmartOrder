using SmartOrder.Web.ViewModels.Table;

namespace SmartOrder.Services.Data.Interfaces
{
    public interface ITableService
    {
        Task<IEnumerable<TableViewModel>> GetAllTablesAsync(string venueId);
        Task<bool> AddTableAsync(TableViewModel table);
        Task<bool> DeleteTableAsync(Guid tableId);
        Task<Guid?> GetVenueIdByTableTokenAsync(string token);
        Task<Guid> GetTableIdByTokenAsync(string token);
        Task<string> GetTokenByTableIdAsync(Guid tableId);
    }
}
