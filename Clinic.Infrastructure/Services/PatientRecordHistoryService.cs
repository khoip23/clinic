using Clinic.Application;
using Clinic.Application.DTOs;
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
        
        public async Task<List<PatientRecordHistoryDto>> GetPatientRecordHistoryAsync(int patientId)
        {
            var query = _context.PatientRecords.Where(r => r.PatientId == patientId);

            return await query.Select(r => new PatientRecordHistoryDto
            {
                PatientRecordId = r.Id,
                PatientId = r.PatientId,
                CreatedAt = r.CreatedAt,
                AppointmentId = r.AppointmentId
            }).ToListAsync();
        }
    }
}
