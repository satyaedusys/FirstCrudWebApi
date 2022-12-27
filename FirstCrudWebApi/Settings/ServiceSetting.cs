using BusinessLayer.Services;
using BusinessLayer.Services.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FirstCrudWebApi.Settings
{
    public static class ServiceSetting
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ICustomerInterface, CustomerService>();
        }
    }
}
