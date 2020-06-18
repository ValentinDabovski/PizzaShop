using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaShop.Extensions;
using PizzaShop.Identity.Extensions;
using PizzaShop.Identity.Services.Identity;

namespace PizzaShop.Identity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
              services
               .AddWebService<IdentityDbContext>(this.Configuration)
               .AddUserStorage()
               .AddTransient<IIdentityService, IdentityService>()
               .AddTransient<ITokenGeneratorService, TokenGeneratorService>();
        }
       

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app
              .UseWebService(env)
              .Initialize();
        }
    }
}
