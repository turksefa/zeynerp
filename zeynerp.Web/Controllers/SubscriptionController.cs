using AutoMapper;
using Iyzipay.Model.V2.Subscription;
using Microsoft.AspNetCore.Mvc;
using zeynerp.Application.DTOs;
using zeynerp.Application.Interfaces;
using zeynerp.Web.Models;

namespace zeynerp.Web.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly IPlanService _planService;
        private readonly ITenantPlanService _tenantPlanService;
        private readonly IMapper _mapper;

        public SubscriptionController(IPlanService planService, ITenantPlanService tenantPlanService, IMapper mapper)
        {
            _planService = planService;
            _tenantPlanService = tenantPlanService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TenantPlanViewModel tenantPlanViewModel = new TenantPlanViewModel();
            tenantPlanViewModel.TenantPlanDtos = await _tenantPlanService.GetTenantPlansByTenantIdAsync((Guid)HttpContext.Items["TenantId"]);

            return View(tenantPlanViewModel);
        }

        public async Task<IActionResult> Plans()
        {
            SubscriptionViewModel subscriptionViewModel = new SubscriptionViewModel();
            subscriptionViewModel.PlanViewModels = _mapper.Map<List<PlanViewModel>>(await _planService.GetPlansAsync());

            return View(subscriptionViewModel);
        }
    }
}