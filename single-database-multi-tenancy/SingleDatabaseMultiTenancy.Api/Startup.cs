using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SingleDatabaseMultiTenancy.Api.Configuracoes;
using SingleDatabaseMultiTenancy.Api.Dependencies;
using SingleDatabaseMultiTenancy.Api.Middleware;
using SingleDatabaseMultiTenancy.Service.AutoMapper;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace SingleDatabaseMultiTenancy.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Name = configuration.GetValue<string>("Application:Name");
            Version = configuration.GetValue<string>("Application:Version");
            DefaultConnection = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }

        public string Name { get; }

        public string Version { get; }

        public string DefaultConnection { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers()
                .AddOData(opt => opt.Select().Expand().Filter().OrderBy().SetMaxTop(100).Count()
                    .AddRouteComponents("OData", EdmModelConfig.GetEdmModel()));

            services.AddJwtSetup();
            services.AddSwaggerSetup(Name, Version);
            services.AddAutoMapper(typeof(AutoMapping));
            services.RegisterDependencies(DefaultConnection);
            services.AddScoped<IAuthorizationHandler, TenantMiddleware>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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
                ui.DocumentTitle = "SingleDatabaseMultiTenancy";
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