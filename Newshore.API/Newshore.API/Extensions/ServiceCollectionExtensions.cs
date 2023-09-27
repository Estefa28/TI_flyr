using Microsoft.EntityFrameworkCore;
using Newshore.EF;

namespace Newshore.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureEF(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DB"),
                sqloption =>
                {
                    sqloption.EnableRetryOnFailure(3);
                    sqloption.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName);
                }));
        }
    }
}
