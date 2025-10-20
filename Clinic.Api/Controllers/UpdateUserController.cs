using Clinic.Application.DTOs;
using Clinic.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{
    [ApiController]
    [Route("api/update")]
    //[Authorize(Roles = "Admin")]
    public class UpdateUserController : ClinicBaseController
    {
        private readonly IUserService _userService;
        public UpdateUserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPut("update/{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, [FromBody] UpdateUserDto dto)
        {
            var respone = await _userService.UpdateEmployeeAsync(userId, dto);

            return Ok(respone);
        }
    }
}
