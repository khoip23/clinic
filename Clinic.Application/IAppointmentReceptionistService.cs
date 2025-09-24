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
    public interface IAppointmentReceptionistService
    {
        Task<List<AppointmentReceptionistDto>> SearchAppointmentsAsync(int? userId, string PatientName, StatusAppointment? status = StatusAppointment.Active);
    }
}
