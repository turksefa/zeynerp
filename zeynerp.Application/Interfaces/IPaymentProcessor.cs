using zeynerp.Application.DTOs;

namespace zeynerp.Application.Interfaces
{
    public interface IPaymentProcessor
    {
        Task<(bool Success, string Error, string HtmlContent)> Initialize3DPaymentAsync(PaymentDto paymentDto);
    }
}