namespace SmartOrder.Services.Data.Interfaces
{
    public interface INotificationService
    {
        Task AddNotificationAsync(string message);
        Task<IEnumerable<string>> GetNotificationsAsync();
    }
}
