using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTree.Api.Configuration
{
    public static class InstallCors
    {
        public static void AddCorsConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var corsBuilder = new CorsPolicyBuilder();

            //corsBuilder.AllowAnyOrigin();// For anyone access. // doesn't work
            corsBuilder.WithOrigins(
                configuration["WhitelistedOrigin"].Split(",")
            );
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowCredentials();
            corsBuilder.AllowAnyMethod();

            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
            });
        }
    }
}
