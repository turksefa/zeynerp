using zeynerp.Application.DTOs;

namespace zeynerp.Application.Interfaces
{
    public interface IPaymentService
    {
        Task<(bool Success, string Error, string HtmlContent)> Process3DPaymentAsync(PaymentDto paymentDto);
        Task<(bool Success, string Error)> PaymentCallbackAsync(CallbackParameters callbackParameters);
    }
}