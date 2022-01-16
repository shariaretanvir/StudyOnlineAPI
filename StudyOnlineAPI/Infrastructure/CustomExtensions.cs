using Microsoft.Extensions.DependencyInjection;
using StudyOnlineAPI.Filters;
using StudyOnlineAPI.ServiceLayer.Classes;
using StudyOnlineAPI.ServiceLayer.ServiceUnitofWork;
using StudyOnlineRepository.RepositoryLayer.UnitofWork;

namespace StudyOnlineAPI.Infrastructure
{
    public static class CustomExtensions
    {
        public static IServiceCollection CustomService(this IServiceCollection services)
        {
            services.AddScoped<RequestResponseLoggingFilterAttribute>();
            services.AddScoped<CommonValidationFilterAttribute>();
            services.AddScoped<RequestResponseLoggingFilterAttribute>();
            services.AddScoped<IserviceUnitofWork, ServiceUnitofWork>();
            services.AddScoped<IUnitofWork, UnitofWork>();
            return services;
        }
    }
}
