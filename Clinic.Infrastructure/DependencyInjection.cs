using Clinic.Application;
using Clinic.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

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

            // Đăng ký AuthService
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IAppointmentPatientService, AppointmentsPatientService>();
            services.AddScoped<IAppointmentReceptionistService, AppointmentReceptionistService>();
            services.AddScoped<IPatientRecordService, PatientRecordService>();
            services.AddScoped<IPatientRecordHistoryService, PatientRecordHistoryService>();
        }

        public static void MigrateDatabase(this IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetRequiredService<ClinicDbContext>();
            if (db.Database.GetPendingMigrations().Any())
            {
                db.Database.Migrate();
            }
        }

    }
}
