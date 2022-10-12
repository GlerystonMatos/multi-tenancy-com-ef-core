using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using SingleDatabaseMultiTenancy.Domain.Interfaces.Services;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SingleDatabaseMultiTenancy.Api.Middleware
{
    public class TenantMiddleware : IAuthorizationHandler
    {
        private readonly ITenantService _tenantService;
        private readonly ILogger<TenantMiddleware> _logger;

        public TenantMiddleware(ITenantService tenantService, ILogger<TenantMiddleware> logger)
        {
            _logger = logger;
            _tenantService = tenantService;
        }

        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            Claim clain = context.User.Claims.Where(c => c.Type.Equals("tenant")).SingleOrDefault();
            if (clain != null)
            {
                _tenantService.Set(clain.Value);
            }
            else
            {
                _tenantService.Set("");
            }

            _logger.LogInformation("Tenant: " + _tenantService.Get());
            return Task.CompletedTask;
        }
    }
}