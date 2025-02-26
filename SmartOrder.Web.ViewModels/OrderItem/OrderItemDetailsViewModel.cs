namespace SmartOrder.Web.ViewModels.OrderItem
{
    public class OrderItemDetailsViewModel
    {
        public string ItemName { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
