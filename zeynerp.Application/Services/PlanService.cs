using AutoMapper;
using zeynerp.Application.Interfaces;
using zeynerp.Application.DTOs;
using zeynerp.Core.Exceptions;
using zeynerp.Core.Interfaces;

namespace zeynerp.Application.Services
{
    public class PlanService : IPlanService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        private readonly IMapper _mapper;

        public PlanService(IApplicationUnitOfWork applicationUnitOfWork, IMapper mapper)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<PlanDto>> GetAllPlansAsync() => _mapper.Map<IReadOnlyList<PlanDto>>(await _applicationUnitOfWork.PlanRepository.GetAllAsync());

        public async Task<(bool Success, string Error, PlanDto? planDto)> GetPlanByIdAsync(Guid planId)
        {
            var plan = await _applicationUnitOfWork.PlanRepository.GetByIdAsync(planId);
            // if(plan == null)
            //     return (false, "Plan bulunamadı.", null);
            if (plan == null)
                throw new EntityNotFoundException("Plan bulunamadı.");

            return (true, string.Empty, _mapper.Map<PlanDto>(plan));
        }
    }
}