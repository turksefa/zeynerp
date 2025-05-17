using zeynerp.Application.DTOs;
using zeynerp.Application.Interfaces;
using zeynerp.Core.Entities;
using zeynerp.Core.Interfaces;

namespace zeynerp.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private IPaymentProcessor _paymentProcessor;
        private IApplicationUnitOfWork _applicationUnitOfWork;

        public PaymentService(IPaymentProcessor paymentProcessor, IApplicationUnitOfWork applicationUnitOfWork)
        {
            _paymentProcessor = paymentProcessor;
            _applicationUnitOfWork = applicationUnitOfWork;
        }

        public async Task<(bool Success, string Error, string HtmlContent)> Process3DPaymentAsync(PaymentDto paymentDto)
        {
            var result = await _paymentProcessor.Initialize3DPaymentAsync(paymentDto);
            return result;
        }

        public async Task<(bool Success, string Error)> PaymentCallbackAsync(CallbackParameters callbackParameters)
        {
            if(callbackParameters.Status == "success")
            {
                var tenantPlan = new TenantPlan
                {
                    TenantId = callbackParameters.TenantId,
                    PlanId = callbackParameters.PlanId,
                    ExpiryDate = DateTime.Now.AddMonths(1),
                    IsActive = true
                };
                await _applicationUnitOfWork.TenantPlanRepository.AddAsync(tenantPlan);
            }
            
            return (false, "Payment failed");
        }
    }
}