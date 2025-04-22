using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using zeynerp.Application.Interfaces;
using zeynerp.Web.Models;

namespace zeynerp.Web.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPlanService _planService;
        private readonly IMapper _mapper;

        public PaymentController(IPlanService planService, IMapper mapper)
        {
            _planService = planService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Checkout([FromQuery] Guid planId)
        {
            PaymentViewModel paymentViewModel = new PaymentViewModel();

            var result = await _planService.GetPlanByIdAsync(planId);
            if (result.Success)
                paymentViewModel.PlanViewModel = _mapper.Map<PlanViewModel>(result.planDto);
            else
                ModelState.AddModelError(string.Empty, result.Error);

            return View(paymentViewModel);
        }
    }
}