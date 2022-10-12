using Microsoft.Extensions.DependencyInjection;
using SingleDatabaseMultiTenancy.Data.Repositories;
using SingleDatabaseMultiTenancy.Domain.Interfaces.Data;

namespace SingleDatabaseMultiTenancy.CrossCutting
{
    public static class InjectorRepository
    {
        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}