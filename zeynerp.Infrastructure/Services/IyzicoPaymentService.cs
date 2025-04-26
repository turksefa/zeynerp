using System.Globalization;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.Extensions.Configuration;
using zeynerp.Application.DTOs;
using zeynerp.Application.Interfaces;

namespace zeynerp.Infrastructure.Services
{
    public class IyzicoPaymentService : IPaymentService
    {
        private readonly Options _options;

        public IyzicoPaymentService(IConfiguration configuration)
        {
            _options = new Options
            {
                ApiKey = configuration["Iyzico:ApiKey"],
                SecretKey = configuration["Iyzico:SecretKey"],
                BaseUrl = configuration["Iyzico:BaseUrl"]
            };
        }
        public async Task<(bool Success, string Error)> ProcessPaymentAsync(PaymentDto paymentDto)
        {
            CreatePaymentRequest paymentRequest = new CreatePaymentRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = Guid.NewGuid().ToString(),
                Price = paymentDto.Price.ToString(CultureInfo.InvariantCulture),
                PaidPrice = paymentDto.Price.ToString(CultureInfo.InvariantCulture),
                Currency = Currency.TRY.ToString(),
                BasketId = paymentDto.PlanId.ToString(),
                PaymentChannel = PaymentChannel.WEB.ToString(),
                PaymentGroup = PaymentGroup.PRODUCT.ToString(),
                CallbackUrl = $"http://localhost:5294/Payment/Callback?planId={paymentDto.PlanId}"
            };

            PaymentCard paymentCard = new PaymentCard
            {
                CardHolderName = paymentDto.HolderName,
                CardNumber = paymentDto.CardNumber,
                ExpireMonth = paymentDto.ExpireMonth,
                ExpireYear = paymentDto.ExpireYear,
                Cvc = paymentDto.CVC,
                RegisterCard = 0
            };
            paymentRequest.PaymentCard = paymentCard;

            Buyer buyer = new Buyer
            {
                Id = "BY789",
                Name = "John",
                Surname = "Doe",
                GsmNumber = "+905350000000",
                Email = "email@email.com",
                IdentityNumber = "74300864791",
                RegistrationDate = "2015-10-05 12:43:35",
                LastLoginDate = "2015-10-05 12:43:35",
                RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                City = "Istanbul",
                Country = "Turkey",
                ZipCode = "34732",
                Ip = "85.34.78.112"
            };
            paymentRequest.Buyer = buyer;

            Address shippingAddress = new Address
            {
                ContactName = "Jane Doe",
                City = "Istanbul",
                Country = "Turkey",
                Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                ZipCode = "34742"
            };
            paymentRequest.ShippingAddress = shippingAddress;

            Address billingAddress = new Address
            {
                ContactName = "Jane Doe",
                City = "Istanbul",
                Country = "Turkey",
                Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                ZipCode = "34742"
            };
            paymentRequest.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem basketItem = new BasketItem
            {
                Id = "BI101",
                Name = "Binocular",
                Category1 = "Collectibles",
                Category2 = "Accessories",
                ItemType = BasketItemType.PHYSICAL.ToString(),
                Price = paymentDto.Price.ToString(CultureInfo.InvariantCulture)
            };
            basketItems.Add(basketItem);
            paymentRequest.BasketItems = basketItems;

            ThreedsInitialize threedsInitialize = await ThreedsInitialize.Create(paymentRequest, _options);

            return (threedsInitialize.Status == "success", threedsInitialize.ErrorMessage); 
        }
    }
}