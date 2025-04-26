using zeynerp.Application.DTOs;

namespace zeynerp.Application.Interfaces
{
    public interface IPaymentService
    {
        Task<(bool Success, string Error)> ProcessPaymentAsync(PaymentDto paymentDto);
    }
}