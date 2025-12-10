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
    public class AppointmentsPatientService : IAppointmentPatientService
    {
        private readonly ClinicDbContext _context;
        public AppointmentsPatientService(ClinicDbContext context) 
        {
            _context = context;
        }

        public async Task<List<AppointmentPatientDto>> GetAppointmentsForPatientAsync(int patientId, StatusAppointment? status = StatusAppointment.Active)
        {
            var query = _context.Appointments
                        .Where(a => a.UserId == patientId);

            if (status.HasValue)
            {
                query = query.Where(a => a.Status == (int)status.Value);
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

        public async Task<bool> CancelAppointmentAsync(int appointmentId, int patientId)
        {
            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(a => a.Id == appointmentId && a.UserId == patientId);

            if (appointment == null)
                return false;

            appointment.Status = (int)StatusAppointment.Canceled;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}