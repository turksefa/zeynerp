using zeynerp.Application.DTOs;

namespace zeynerp.Application.Interfaces
{
    public interface IPlanService
    {
        Task<IReadOnlyList<PlanDto>> GetAllPlansAsync();
        Task<(bool Success, string Error, PlanDto? planDto)> GetPlanByIdAsync(Guid planId);
    }
}