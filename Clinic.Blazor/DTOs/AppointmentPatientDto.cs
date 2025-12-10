namespace Clinic.Blazor.DTOs
{
    public enum StatusAppointment
    {
        Active = 1,
        Visitted = 2,
        Canceled = 3,
    }
    public class AppointmentPatientDto
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public StatusAppointment Status { get; set; }
        public int? DoctorId { get; set; }
    }
}
