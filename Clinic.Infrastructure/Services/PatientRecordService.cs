using Clinic.Application.DTOs;
using Clinic.Application.Interface;
using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Infrastructure.Services
{
    public class PatientRecordService : IPatientRecordService
    {
        private readonly ClinicDbContext _context;
        public PatientRecordService(ClinicDbContext context)
        {
            _context = context;
        }
        public async Task<PatientRecordDto> CreatePatientRecordAsync(CreatePatientRecordInputDto input, int receivedBy)
        {
            var patient = await _context.Patients
                .FirstOrDefaultAsync(p => p.PhoneNumber == input.PhoneNumber);

            if (patient == null)
            {
                patient = new Patient
                {
                    FullName = input.FullName,
                    DOB = input.DOB,
                    PhoneNumber = input.PhoneNumber,
                    Address = input.Address,
                    CreatedAt = DateTime.UtcNow
                };

                _context.Patients.Add(patient);
                await _context.SaveChangesAsync();
            }

            var patientRecord = new PatientRecord
            {
                PatientId = patient.Id,
                ReceivedBy = receivedBy,
                AppointmentId = input.AppointmentId,
                CreatedAt = DateTime.UtcNow
            };

            _context.PatientRecords.Add(patientRecord);
            await _context.SaveChangesAsync();

            return new PatientRecordDto
            {
                Id = patientRecord.Id,
                PatientId = patient.Id,
                ReceivedBy = patientRecord.ReceivedBy,
                AppointmentId = patientRecord.AppointmentId,
                CreatedAt = patientRecord.CreatedAt,
                FullName = patient.FullName,
                DOB = patient.DOB,
                PhoneNumber = patient.PhoneNumber,
                Address = patient.Address
            };
        }

    }
}
