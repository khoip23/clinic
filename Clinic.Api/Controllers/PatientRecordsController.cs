﻿using Clinic.Application;
using Clinic.Application.DTOs;
using Clinic.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Clinic.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Receptionist")]
    public class PatientRecordsController : ControllerBase
    {
        private readonly IPatientRecordService _patientRecordService;

        public PatientRecordsController(IPatientRecordService patientRecordService)
        {
            _patientRecordService = patientRecordService;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "Receptionist,Admin")]
        public async Task<IActionResult> Create([FromBody] CreatePatientRecordInputDto input)
        {
            // Lấy id user đang đăng nhập (nhân viên tiếp nhận)
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out var receivedBy))
            {
                return Unauthorized(new { message = "Không tìm thấy thông tin người dùng" });
            }

            var result = await _patientRecordService.CreatePatientRecordAsync(input, receivedBy);
            return Ok(result);
        }
    }
}
