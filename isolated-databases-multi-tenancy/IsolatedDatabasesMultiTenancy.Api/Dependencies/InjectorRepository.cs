using IsolatedDatabasesMultiTenancy.Data.Repositories;
using IsolatedDatabasesMultiTenancy.Domain.Interfaces.Data;
using Microsoft.Extensions.DependencyInjection;

namespace IsolatedDatabasesMultiTenancy.Api.Dependencies
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