using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using BookingLibrary.Infrastructure.InjectionFramework;
using BookingLibrary.Infrastructure.Messaging.RabbitMQ;
using BookingLibrary.Domain.Core.Messaging;
using Microsoft.Extensions.DependencyInjection;
using BookingLibrary.Service.Identity.Domain;
using BookingLibrary.Service.Identity.Domain.DataAccessors;
using BookingLibrary.Infrastructure.DataPersistence.Identity.SQLServer;

namespace BookingLibrary.Service.Identity
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            InjectService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseMvc(r =>
            {
                r.MapRoute("default", "api/{controller}/{id?}");
            });
        }

        private void InjectService()
        {
            InjectContainer.RegisterType<IPasswordHasher, PlainTextPasswordHasher>();
            InjectContainer.RegisterType<IIdentityReadDBConnectionStringProvider, AppsettingRepositoryReadDBConnectionStringProvider>();
            InjectContainer.RegisterType<IIdentityWriteDBConnectionStringProvider, AppsettingRepositoryWriteDBConnectionStringProvider>();
            InjectContainer.RegisterType<IIdentityReportDataAccessor, IdentityReportDataAccessor>();
        }
    }
}
