namespace SmartOrder.Services.Data.Interfaces
{
    public interface IQRCodeService
    {
        byte[] GenerateQRCode(string token);
    }
}
