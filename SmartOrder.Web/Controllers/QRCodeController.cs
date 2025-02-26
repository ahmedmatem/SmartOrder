using Microsoft.AspNetCore.Mvc;
using SmartOrder.Services.Data.Interfaces;

namespace SmartOrder.Web.Controllers
{
    public class QRCodeController : BaseController
    {
        private readonly IQRCodeService qrCodeService;

        public QRCodeController(IQRCodeService qrCodeService)
        {
            this.qrCodeService = qrCodeService;
        }

        [HttpGet]
        public IActionResult Generate(string? token)
        {
            var qrCode = qrCodeService.GenerateQRCode(token);
            return File(qrCode, "image/png");
        }
    }
}
