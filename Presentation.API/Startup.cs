using Autofac;
using Autofac.Extensions.DependencyInjection;
using FVG.FiscalPrinter.Domain.Core.Data;
using FVG.FiscalPrinter.Domain.Core.Modules;
using FVG.FiscalPrinter.Presentation.API.Configuration;
using FVG.FiscalPrinter.Presentation.API.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FVG.FiscalPrinter
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.Configure<APIUrl>(Configuration.GetSection("APIUrl"));

            var connectionString = Configuration.GetConnectionString("CnnDB");
            services.AddEntityFrameworkNpgsql().AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));

            // Register the service and implementation for the database context
            services.AddScoped<IDataContext>(provider => provider.GetService<DataContext>());

            var builder = new ContainerBuilder();
            builder.RegisterType<PrintProcessor>().As<IPrintProcessor>();
            builder.RegisterType<CommandProcessor>().As<ICommandProcessor>();

            builder.RegisterModule(new CoreModule());

            builder.Populate(services);
            var container = builder.Build();

            return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "api/{controller}/{id?}");
            });
        }
    }
}