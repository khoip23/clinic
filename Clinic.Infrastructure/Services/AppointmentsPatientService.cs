using Clinic.Application;
using Clinic.Application.DTOs;
using Clinic.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Infrastructure.Services
{
    public class AppointmentsPatientService : IAppointmentPatientService
    {
        private readonly ClinicDbContext _context;
        public AppointmentsPatientService(ClinicDbContext context) 
        {
            _context = context;
        }

        public async Task<List<AppointmentPatientDto>> GetAppointmentsForPatientAsync(int patientId, string status = "Active")
        {
            var query = _context.Appointments
                .Include(a => a.Doctor)
                .Where(a => a.UserId == patientId);

            if(!string.IsNullOrWhiteSpace(status))
            {
                if(Enum.TryParse<StatusAppointment>(status, true, out var parsedStatus))
                {
                    query = query.Where(a => a.Status == (int)parsedStatus);
                }    
            }

            return await query
                .Select(a => new AppointmentPatientDto
                {
                    Id = a.Id,
                    Date = a.Date,
                    Time = a.Time,
                    Status = a.Status,
                    DoctorId = a.DoctorId
                })
                .ToListAsync();
        }
    }
}
