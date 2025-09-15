using Clinic.Application.DTOs;
using Clinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application
{
    public interface IAppointmentService
    {
        Task<Appointment> CreateAppointmentAsync(int userId, CreateAppointmentRequest request);
    }
}
