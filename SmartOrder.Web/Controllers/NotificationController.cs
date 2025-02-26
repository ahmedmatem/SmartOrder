using Microsoft.AspNetCore.Mvc;
using SmartOrder.Services.Data.Interfaces;

namespace SmartOrder.Web.Controllers
{
    public class NotificationController : BaseController
    {
        private readonly INotificationService notificationService;

        public NotificationController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<string> notifications = await notificationService.GetNotificationsAsync();
            return View(notifications);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return BadRequest("Notification message cannot be empty.");
            }

            await notificationService.AddNotificationAsync(message);
            return RedirectToAction(nameof(Index));
        }
    }
}
