using Clinic.Application.DTOs;
using Clinic.Domain;
using Clinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application
{
    public interface IAppointmentPatientService
    {
        Task<List<AppointmentPatientDto>> GetAppointmentsForPatientAsync(int patientId, StatusAppointment? status = StatusAppointment.Active);
    }
}
