namespace IsolatedDatabasesMultiTenancy.Domain.Tenant
{
    public class TenantConfiguration
    {
        public string Name { get; set; }

        public string ConnectionString { get; set; }
    }
}