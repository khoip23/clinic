using Clinic.Application;
using Clinic.Application.DTOs;
using Clinic.Domain;
using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Infrastructure.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ClinicDbContext _context;
        public AppointmentService(ClinicDbContext context)
        {
            _context = context;
        }

        public async Task<Appointment> CreateAppointmentAsync(int UserId, CreateAppointmentRequestDto request)
        {
            if(request.DoctorId == null)
            {
                var DoctorExists = await _context.Users.AnyAsync(u => u.Id == request.DoctorId.Value);

                if(!DoctorExists)
                {
                    throw new KeyNotFoundException("Không tìm thấy bác sĩ tương ứng");
                }    
            }

            var appointment = new Appointment()
            {
                UserId = UserId,
                DoctorId = request.DoctorId,
                Date = DateOnly.FromDateTime(request.Date),
                Time = TimeOnly.FromTimeSpan(request.Time),
                CreatedAt = DateTime.UtcNow,
                Status = (int)StatusAppointment.Active,
                VisittedAt = null,
                CanceledAt = null
            };

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            return appointment;
        }
    }
}
