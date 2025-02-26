namespace SmartOrder.Web.ViewModels.Venue
{
    public class VenueViewModel
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string City { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
    }
}
