using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using zeynerp.Application.Services;

namespace zeynerp.Infrastructure
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ITenantService tenantService)
        {
            var userId = context.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrEmpty(userId) && context.User.Identity.IsAuthenticated)
            {
                var tenant = await tenantService.GetTenantAsync(userId);

                if (tenant != null)
                {
                    context.Items["TenantId"] = tenant.Id;
                }
            }

            await _next(context);
        }
    }
}