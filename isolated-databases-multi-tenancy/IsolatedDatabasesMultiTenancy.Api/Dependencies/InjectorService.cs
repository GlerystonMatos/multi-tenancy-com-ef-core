using IsolatedDatabasesMultiTenancy.Domain.Interfaces.Services;
using IsolatedDatabasesMultiTenancy.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IsolatedDatabasesMultiTenancy.Api.Dependencies
{
    public static class InjectorService
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddScoped<ITenantService, TenantService>();
            services.AddScoped<IAnimalService, AnimalService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}