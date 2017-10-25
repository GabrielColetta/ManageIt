using ManageIt.Application.Applications;
using ManageIt.Data.Context;
using ManageIt.Domain.Contracts.Applications;
using Microsoft.Extensions.DependencyInjection;

namespace ManageIt.Api
{
    public partial class Startup
    {
        private void ApplicationService(IServiceCollection services)
        {
            //CONTEXTO
            services.AddTransient<ConfigurationContext, ConfigurationContext>();

            //COMPONENTES.

            //SERVIÇOS
            services.AddTransient<IHomeApplication, HomeApplication>();
        }
    }
}
