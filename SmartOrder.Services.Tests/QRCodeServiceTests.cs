using SmartOrder.Services.Data;

namespace SmartOrder.Services.Tests
{
    [TestFixture]
    public class QRCodeServiceTests
    {
        private QRCodeService qrCodeService;

        [SetUp]
        public void Setup()
        {
            qrCodeService = new QRCodeService();
        }

        [Test]
        public void GenerateQRCode_ShouldThrowException_WhenTokenIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => qrCodeService.GenerateQRCode(string.Empty));
        }
    }
}
