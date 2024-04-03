using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SingleDatabaseMultiTenancy.Data.Context;

namespace SingleDatabaseMultiTenancy.Api.Dependencies
{
    public static class InjectorDependencies
    {
        public static void RegisterDependencies(this IServiceCollection services, string defaultConnection)
        {
            services.AddDbContext<SingleDatabaseMultiTenancyContext>(options => options.UseSqlServer(defaultConnection));
            services.RegisterRepository();
            services.RegisterService();
        }
    }
}