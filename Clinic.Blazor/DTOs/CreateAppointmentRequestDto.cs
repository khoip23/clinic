namespace Clinic.Blazor.DTOs
{
    public class CreateAppointmentRequestDto
    {
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public int? DoctorId { get; set; }
    }
}
