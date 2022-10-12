using IsolatedDatabasesMultiTenancy.Domain.Interfaces.Services;
using IsolatedDatabasesMultiTenancy.Domain.Tenant;

namespace IsolatedDatabasesMultiTenancy.Service.Services
{
    public class TenantService : ITenantService
    {
        private TenantConfiguration _tenant;

        public TenantConfiguration Get()
            => _tenant;

        public void Set(TenantConfiguration tenant)
            => _tenant = tenant;
    }
}