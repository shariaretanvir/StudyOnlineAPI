using Microsoft.Extensions.DependencyInjection;

namespace StudyOnlineAPI.Infrastructure
{
    public static class CORSExtension
    {
        public static IServiceCollection CustomCORS(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(c =>
                {
                    c.WithOrigins("https://localhost")
                    .AllowAnyOrigin()
                    .AllowAnyMethod();
                });
            });
            return services;
        }
    }
}
