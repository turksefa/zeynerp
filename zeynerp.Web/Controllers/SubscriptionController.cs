using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using zeynerp.Application.Interfaces;
using zeynerp.Web.Models;

namespace zeynerp.Web.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly IPlanService _planService;
        private readonly IMapper _mapper;

        public SubscriptionController(IPlanService planService, IMapper mapper)
        {
            _planService = planService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Plans()
        {
            SubscriptionViewModel subscriptionViewModel = new SubscriptionViewModel();
            subscriptionViewModel.PlanViewModels = _mapper.Map<List<PlanViewModel>>(await _planService.GetAllPlansAsync());

            return View(subscriptionViewModel);
        }
    }
}