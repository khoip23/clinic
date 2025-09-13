using Clinic.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Infrastructure
{
    public static class DependencyInjection
    {
        // static method
        // thêm this => extension method
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ClinicDbContext>((opts) =>
            {
                var connectionString = configuration.GetSection("ConnectionStrings")["DefaultConnection"];
                opts.UseSqlServer(connectionString);
            });

            using var scope = services.BuildServiceProvider().CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ClinicDbContext>();
            if (db.Database.GetPendingMigrations().Any())
            {
                db.Database.Migrate();
            }

            // Đăng ký AuthService
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
