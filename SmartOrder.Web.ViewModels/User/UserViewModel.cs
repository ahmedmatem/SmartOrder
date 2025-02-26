namespace SmartOrder.Web.ViewModels.User
{
    public class UserViewModel
    {
        public string Id { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string? Email { get; set; }
        public string Role { get; set; } = null!;
    }
}
