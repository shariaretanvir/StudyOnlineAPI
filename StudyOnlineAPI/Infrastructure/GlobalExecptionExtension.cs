using Microsoft.AspNetCore.Builder;
using StudyOnlineAPI.Middlewares;

namespace StudyOnlineAPI.Infrastructure
{
    public static class GlobalExecptionExtension
    {
        public static IApplicationBuilder UseGlobalError(this IApplicationBuilder app)
            => app.UseMiddleware<GlobalException>();
    }
}
