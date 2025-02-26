using SmartOrder.Services.Data.Interfaces;

namespace SmartOrder.Services.Data
{
    public class NotificationService : BaseService, INotificationService
    {
        private readonly List<string> notifications = new List<string>();

        public Task AddNotificationAsync(string message)
        {
            this.notifications.Add(message);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<string>> GetNotificationsAsync()
        {
            return Task.FromResult<IEnumerable<string>>(this.notifications);
        }
    }
}
