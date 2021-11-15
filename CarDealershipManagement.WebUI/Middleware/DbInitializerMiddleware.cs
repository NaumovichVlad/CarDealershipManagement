using CarDealershipManagement.Core.Config;
using CarDealershipManagement.Infrastructure.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace CarDealershipManagement.WebUI.Middleware
{
    public class DbTestInitializerMiddleware
    {

        private readonly RequestDelegate _next;
        public DbTestInitializerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public Task Invoke(HttpContext context, IServiceProvider serviceProvider, CarDealershipContext dbContext)
        {
            return _next.Invoke(context);
        }

    }

    public static class DbInitializerExtensions
    {
        public static IApplicationBuilder UseDbInitializer(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DbTestInitializerMiddleware>();
        }

    }
}
