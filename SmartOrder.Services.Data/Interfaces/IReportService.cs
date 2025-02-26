using SmartOrder.Web.ViewModels.Report;

namespace SmartOrder.Services.Data.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<SalesReportViewModel>> GetSalesReportAsync(string venueId);
    }
}
