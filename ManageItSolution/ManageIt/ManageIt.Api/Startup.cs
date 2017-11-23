using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ManageIt.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

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
                options.UseSqlServer(Configuration.GetConnectionString("connectionstring")));

            this.ApplicationService(services);
            this.ConfigureAuth(services);
            services.AddOptions();
            IMvcCoreBuilder mvcCoreBuilder = services.AddMvcCore(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                         .RequireAuthenticatedUser()
                         .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });

            mvcCoreBuilder.AddFormatterMappings()
                .AddJsonFormatters()
                .AddCors();
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
            app.UseMvc();
        }
    }
}
