using Microsoft.Extensions.DependencyInjection;
using IsolatedDatabasesMultiTenancy.Data.Repositories;
using IsolatedDatabasesMultiTenancy.Domain.Interfaces.Data;

namespace IsolatedDatabasesMultiTenancy.CrossCutting
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