using AppTree.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppTree.Api.Configuration
{
    public static class InstallDatabase
    {
        public static IServiceCollection AddDatabase(this IServiceCollection @this, IConfiguration configuration)
        {
            @this.AddPersistance(configuration);
            return @this;
        }
    }
}
