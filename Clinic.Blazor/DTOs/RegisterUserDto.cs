using System.ComponentModel.DataAnnotations;

namespace Clinic.Blazor.DTOs
{
    public class RegisterUserDto
    {
        public string PhoneNumber { get; set; } = "";
        public string FullName { get; set; } = "";
        public DateTime DOB { get; set; }
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
