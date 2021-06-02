using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using AppTree.Domain.AggregateModels.ApplicationAggregate;
using AppTree.Infrastructure.Repositories;

namespace AppTree.Infrastructure
{
    public static class DependencyInjectionRegister
    {
        public static IServiceCollection AddPersistance(this IServiceCollection @this, IConfiguration configuration)
        {
            
            @this.AddDbContext<AppTreeContext, AppTreeContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("AppTreeContext"),
                    providerOptions =>
                    {
                        providerOptions.EnableRetryOnFailure();
                        providerOptions.MigrationsAssembly("AppTree.Infrastructure");
                    }
                );

            });

            @this.AddScoped<IApplicationRepository, ApplicationRepository>();

            @this.AddScoped<IApplicationDependencyRepository, ApplicationDependencyRepository>();
            @this.AddScoped<IApplicationEnvironmentRepository, ApplicationEnvironmentRepository>();

            return @this;
        }
    }
}

