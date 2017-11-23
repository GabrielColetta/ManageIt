using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ManageIt.Api
{
    public partial class Startup
    {
        private const string SecretKey = "needtogetthisfromenvironment";
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

        public void ConfigureAuth(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("DisneyUser",
                                  policy => policy.RequireClaim("DisneyCharacter", "IAmMickey"));
            });
        }
    }
}
