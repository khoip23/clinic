using Clinic.Application.DTOs;
using Clinic.Application.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Infrastructure.Services
{
    public class PatientRecordHistoryService : IPatientRecordHistoryService
    {
        private readonly ClinicDbContext _context;
        public PatientRecordHistoryService(ClinicDbContext context) 
        {
            _context = context;
        }
        
        public async Task<List<PatientRecordHistoryDto>> GetPatientRecordHistoryAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if(user == null) return new List<PatientRecordHistoryDto>();

            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.PhoneNumber == user.PhoneNumber);
            if(patient == null) return new List<PatientRecordHistoryDto>();

            return await _context.PatientRecords
                .Where(r => r.PatientId == patient.Id)
                .Select(r => new PatientRecordHistoryDto
                {
                    PatientRecordId = r.Id,
                    PatientId = r.PatientId,
                    AppointmentId = r.AppointmentId,
                    CreatedAt = r.CreatedAt
                }).ToListAsync();
        }
    }
}
