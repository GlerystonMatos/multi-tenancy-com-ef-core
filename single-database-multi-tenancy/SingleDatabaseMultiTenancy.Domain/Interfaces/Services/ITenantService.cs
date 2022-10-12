namespace SingleDatabaseMultiTenancy.Domain.Interfaces.Services
{
    public interface ITenantService
    {
        string Get();

        void Set(string tenant);
    }
}