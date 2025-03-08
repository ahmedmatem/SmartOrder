using Microsoft.EntityFrameworkCore;
using SmartOrder.Data.Models;
using SmartOrder.Data.Repository.Interfaces;
using SmartOrder.Services.Data.Interfaces;
using SmartOrder.Web.ViewModels.Report;

namespace SmartOrder.Services.Data
{
    public class ReportService : BaseService, IReportService
    {
        private readonly IRepository<Order, Guid> orderRepository;

        public ReportService(IRepository<Order, Guid> orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<IEnumerable<SalesReportViewModel>> GetSalesReportAsync(string venueId)
        {
            IEnumerable<Order> orders = await orderRepository
                .GetAllAttached()
                .Include(o => o.Table)
                .Include(o => o.Items)
                .ThenInclude(oi => oi.MenuItem)
                .Where(o => o.Table.VenueId.ToString() == venueId && o.Status == Common.Enums.OrderStatus.Completed)
                .ToListAsync();

            return orders.GroupBy(o => o.Table.TableNumber)
                         .Select(g => new SalesReportViewModel
                         {
                             TableNumber = g.Key.ToString(),
                             TotalOrders = g.Count(),
                             TotalRevenue = g.Sum(o => o.TotalPrice)
                         });
        }
    }
}
