using zeynerp.Application.DTOs;

namespace zeynerp.Application.Interfaces
{
    public interface IPlanService
    {
        Task<IReadOnlyList<PlanDto>> GetPlansAsync();
        Task<(bool Success, string Error, PlanDto? planDto)> GetPlanByIdAsync(Guid planId);
    }
}