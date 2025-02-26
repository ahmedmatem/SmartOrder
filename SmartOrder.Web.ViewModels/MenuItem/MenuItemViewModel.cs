namespace SmartOrder.Web.ViewModels.MenuItem
{
    public class MenuItemViewModel
    {
        public string Id { get; set; } = null!;
        public string MenuCategoryId { get; set; } = null!;
        public string MenuCategoryTitle { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Tags { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
