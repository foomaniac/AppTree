using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace AppTree.Api.Configuration
{
    public static class InstallSwagger
    {
       public static IServiceCollection AddSwagger(this IServiceCollection @this)
        {
            @this.AddSwaggerGen(opt => opt.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "AppTree Api",
                Description = "AppTree Supporting Api"
               
            }));
            return @this;
        }
    }
}
