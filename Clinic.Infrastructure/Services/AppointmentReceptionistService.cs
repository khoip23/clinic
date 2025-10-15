using Clinic.Application.DTOs;
using Clinic.Application.Interface;
using Clinic.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Infrastructure.Services
{
    public class AppointmentReceptionistService : IAppointmentReceptionistService
    {
        private readonly ClinicDbContext _context;
        public AppointmentReceptionistService(ClinicDbContext context)
        {
            _context = context;
        }
        public async Task<List<AppointmentReceptionistDto>> SearchAppointmentsAsync(int? userId, string PatientName, StatusAppointment? status = StatusAppointment.Active)
        {
            var query = _context.Appointments
            .Include(a => a.User)
            .AsQueryable();

            if (userId.HasValue)
            {
                query = query.Where(a => a.UserId == userId.Value);
            }
            if (!string.IsNullOrEmpty(PatientName))
            {
                query = query.Where(a => a.User.FullName.Contains(PatientName));
            }
            if (status.HasValue)
            {
                query = query.Where(a => a.Status == (int)status.Value);
            }

            var result = await query
                .Select(a => new AppointmentReceptionistDto
                {
                    Id = a.Id,
                    Date = a.Date,
                    Time = a.Time, 
                    Status = (int)a.Status,                          
                    DoctorId = a.DoctorId
                })
                .ToListAsync();

            return result;
        }
    }
}
