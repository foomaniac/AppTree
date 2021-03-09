using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

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

            return @this;
        }
    }
}

