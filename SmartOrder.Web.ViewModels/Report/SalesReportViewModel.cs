namespace SmartOrder.Web.ViewModels.Report
{
    public class SalesReportViewModel
    {
        public string TableId { get; set; } = null!;
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
