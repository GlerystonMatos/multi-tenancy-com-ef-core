using IsolatedDatabasesMultiTenancy.Domain.Tenant;

namespace IsolatedDatabasesMultiTenancy.Domain.Interfaces.Services
{
    public interface ITenantService
    {
        TenantConfiguration Get();

        void Set(TenantConfiguration tenant);
    }
}