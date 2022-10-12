using SingleDatabaseMultiTenancy.Domain.Interfaces.Services;

namespace SingleDatabaseMultiTenancy.Service.Services
{
    public class TenantService : ITenantService
    {
        private string _tenant = "";

        public string Get()
            => _tenant;

        public void Set(string tenant)
            => _tenant = tenant;
    }
}