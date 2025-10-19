using Newtonsoft.Json;

namespace Clinic.Blazor.DTOs
{
    public enum RoleType
    {
        Patient = 1,
        Receptionist = 2,
        Doctor = 3,
        Admin = 4,
    }
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public DateTime? DOB { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public RoleType Role { get; set; }
    }
}
