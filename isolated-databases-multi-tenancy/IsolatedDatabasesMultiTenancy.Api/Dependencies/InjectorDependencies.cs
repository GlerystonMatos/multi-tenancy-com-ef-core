using IsolatedDatabasesMultiTenancy.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace IsolatedDatabasesMultiTenancy.Api.Dependencies
{
    public static class InjectorDependencies
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddDbContext<IsolatedDatabasesMultiTenancyContext>();
            services.RegisterRepository();
            services.RegisterService();
        }
    }
}