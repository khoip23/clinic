using Clinic.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Interface
{
    public interface IPatientRecordHistoryService
    {
        Task<List<PatientRecordHistoryDto>> GetPatientRecordHistoryAsync(int userId);
    }
}
