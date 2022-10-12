using Microsoft.Extensions.DependencyInjection;
using SingleDatabaseMultiTenancy.Domain.Interfaces.Services;
using SingleDatabaseMultiTenancy.Service.Services;

namespace SingleDatabaseMultiTenancy.CrossCutting
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