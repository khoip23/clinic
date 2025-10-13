namespace Clinic.Blazor.DTOs
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
