using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ManageIt.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;

namespace ManageIt.Api
{
    public partial class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = configuration.Build();
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ConfigurationContext>(options =>
                options.UseSqlServer("Server=(local)\\SQLEXPRESS01;Database=MANAGEIT;Trusted_Connection=True;"));

            //Faz a injeção de dependências
            ApplicationService(services);
            services.AddOptions();
            services.AddCors();
            services.AddMvcCore();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePagesWithReExecute("/{0}");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("api/error");
            }

            app.UseStaticFiles();
            app.UseCors(builder => builder.AllowAnyHeader());
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaultRoute",
                    template: "api/{controller}/{action}",
                    defaults: new { controller = "Home", action = "Index" });
            });

            //var routeBuilder = new RouteBuilder(app, new RouteHandler(context =>
            //{
            //    return context.Response.WriteAsync("Deu erro!");
            //}));
            //routeBuilder.MapRoute(
            //        name: "defaultRoute",
            //        template: "api/{controller}/{action}",
            //        defaults: new { controller = "home", action = "Index" });
            //app.UseRouter(routeBuilder.Build());
        }
    }
}
