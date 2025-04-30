using Microsoft.EntityFrameworkCore;
using zeynerp.Core.Entities;
using zeynerp.Core.Repositories;
using zeynerp.Infrastructure.Data.Contexts;

namespace zeynerp.Infrastructure.Data.Repositories
{
    public class PlanRepository : Repository<Plan>, IPlanRepository
    {
        public PlanRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}