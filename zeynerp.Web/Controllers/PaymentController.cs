using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using zeynerp.Application.DTOs;
using zeynerp.Application.Interfaces;
using zeynerp.Web.Models;

namespace zeynerp.Web.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPlanService _planService;
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentController(IPlanService planService, IPaymentService paymentService, IMapper mapper)
        {
            _planService = planService;
            _paymentService = paymentService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Checkout([FromQuery] Guid planId)
        {
            PaymentViewModel paymentViewModel = new PaymentViewModel();

            var result = await _planService.GetPlanByIdAsync(planId);
            if (result.Success)
            {
                paymentViewModel.TenantId = (Guid)HttpContext.Items["TenantId"];
                paymentViewModel.PlanViewModel = _mapper.Map<PlanViewModel>(result.planDto);
            }
            else
                ModelState.AddModelError(string.Empty, result.Error);

            return View(paymentViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout([FromForm] PaymentViewModel paymentViewModel)
        {
            var result = await _paymentService.Process3DPaymentAsync(_mapper.Map<PaymentDto>(paymentViewModel));
            if (result.Success)
            {
                TempData["HtmlContent"] = result.HtmlContent;
                return RedirectToAction("Redirect3D");
            }

            ModelState.AddModelError(string.Empty, result.Error);
            return View(paymentViewModel);
        }

        public IActionResult Redirect3D()
        {
            string htmlContent = TempData["HtmlContent"] as string ?? "";
            return View((object)htmlContent);
        }

        [HttpPost]
        public async Task<IActionResult> Callback(Guid planId, Guid tenantId)
        {
            var callbackParameters = new CallbackParameters
            {
                Status = Request.Form["status"].ToString(),
                PlanId = planId,
                TenantId = tenantId
            };
            
            var result = await _paymentService.PaymentCallbackAsync(callbackParameters);
            if (!result.Success)
                ModelState.AddModelError(string.Empty, result.Error);
                        
            return RedirectToAction("Index", "Subscription");
        }
    }
}