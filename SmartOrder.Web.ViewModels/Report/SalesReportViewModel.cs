namespace SmartOrder.Web.ViewModels.Report
{
    public class SalesReportViewModel
    {
        public string TableNumber { get; set; } = null!;
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
