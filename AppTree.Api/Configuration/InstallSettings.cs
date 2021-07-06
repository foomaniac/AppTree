using AppTree.Api.Application.Queries;
using AppTree.Api.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTree.Api.Configuration
{
    public static class InstallSettings
    {
        public static IServiceCollection AddSettings(this IServiceCollection @this, IConfiguration configuration)
        {
            @this.Configure<AppTreeSettings>(configuration.GetSection(AppTreeSettings.ConnectionString));
            return @this;
        }

    }
}
