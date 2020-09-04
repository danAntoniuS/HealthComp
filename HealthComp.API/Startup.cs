using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthComp.BusinessLogic;
using HealthComp.BusinessLogic.Interfaces;
using HealthComp.Repository;
using HealthComp.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HealthComp.API
{
    public class Startup
    {
        private const string WorkItemDbConnectionStringKey = "Data:WorkItemDb:ConnectionString";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //WorkItemManager business layer class DI configuration
            services.AddTransient<IWorkItemManager, WorkItemManager>();

            //example of how we configure DI for a repository, read and pass connection 
            //string into the repository; not needed in our case as it si a mock 
            //just for illustration on how it is done
            var connectionString = Configuration[WorkItemDbConnectionStringKey];
            services.AddTransient<IWorkItemRepository, WorkItemRepository>(
               (provider) =>
               {
                   return new WorkItemRepository(connectionString);
               });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
