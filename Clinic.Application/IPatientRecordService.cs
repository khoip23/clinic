﻿using Clinic.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Infrastructure.Services
{
    public interface IPatientRecordService
    {
        Task<PatientRecordDto> CreatePatientRecordAsync(CreatePatientRecordInputDto input, int ReceivedBy);
    }
}
