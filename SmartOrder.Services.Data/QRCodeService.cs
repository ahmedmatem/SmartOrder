using SmartOrder.Services.Data.Interfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Formats.Png;
using QRCoder.Core;
using System.Text;
using System.Drawing.Imaging;

namespace SmartOrder.Services.Data
{
    public class QRCodeService : BaseService, IQRCodeService
    {
        public byte[] GenerateQRCode(string token)
        {
            if (token == string.Empty)
            {
                throw new ArgumentException("Invalid Table Token");
            }

            string url = $"https://smartorderer.azurewebsites.net/MenuItem?token={token}";
        
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q))
            using (QRCode qrCode = new QRCode(qrCodeData))
            {
                using (var qrCodeBitmap = qrCode.GetGraphic(20))
                {
                    using (var ms = new MemoryStream())
                    {
                        qrCodeBitmap.Save(ms, ImageFormat.Png);
                        return ms.ToArray();
                    }
                }
            }
        }
    }
}
