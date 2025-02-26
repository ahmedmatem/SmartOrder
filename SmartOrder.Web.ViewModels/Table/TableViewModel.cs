namespace SmartOrder.Web.ViewModels.Table
{
    public class TableViewModel
    {
        public string Id { get; set; } = null!;
        public string VenueId { get; set; } = null!;
        public string VenueName { get; set; } = string.Empty;
        public int TableNumber { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}
