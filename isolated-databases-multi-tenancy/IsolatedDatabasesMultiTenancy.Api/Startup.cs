using IsolatedDatabasesMultiTenancy.Api.Configuracoes;
using IsolatedDatabasesMultiTenancy.Api.Dependencies;
using IsolatedDatabasesMultiTenancy.Api.Middleware;
using IsolatedDatabasesMultiTenancy.Domain.Tenant;
using IsolatedDatabasesMultiTenancy.Service.AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace IsolatedDatabasesMultiTenancy.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Name = configuration.GetValue<string>("Application:Name");
            Version = configuration.GetValue<string>("Application:Version");
        }

        public string Name { get; }

        public string Version { get; }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers()
                .AddOData(opt => opt.Select().Expand().Filter().OrderBy().SetMaxTop(100).Count()
                    .AddRouteComponents("OData", EdmModelConfig.GetEdmModel()));

            services.AddJwtSetup();
            services.RegisterDependencies();
            services.AddSwaggerSetup(Name, Version);
            services.AddAutoMapper(typeof(AutoMapping));
            services.Configure<TenantConfigurationSection>(Configuration);
            services.AddScoped<IAuthorizationHandler, TenantMiddleware>();

            services.AddDataProtection()
                .UseCryptographicAlgorithms(
                    new AuthenticatedEncryptorConfiguration()
                    {
                        EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
                        ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
                    });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseExceptionHandlerCuston();

            app.UseSwagger();
            app.UseSwaggerUI(ui =>
            {
                ui.EnableFilter();
                ui.DocExpansion(DocExpansion.None);
                ui.InjectStylesheet("/swagger-ui/custom.css");
                ui.DocumentTitle = "IsolatedDatabasesMultiTenancy";
                ui.SwaggerEndpoint("/swagger/v" + Version + "/swagger.json", Name + " V" + Version);
            });

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}