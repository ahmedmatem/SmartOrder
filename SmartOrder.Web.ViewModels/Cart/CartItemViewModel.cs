namespace SmartOrder.Web.ViewModels.Cart
{
    public class CartItemViewModel
    {
        public string MenuItemId { get; set; } = null!;
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; } = string.Empty;
        public decimal TotalPrice => Quantity * Price;
    }
}
