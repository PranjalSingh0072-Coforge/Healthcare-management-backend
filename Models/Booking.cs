namespace HealthcareManagement.Models
{
    public class Booking
    {
        public int Id { get; set; }
        // public int PatientId { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? Disease { get; set; }
        public string? DoctorName { get; set; }
        public DateTime Date { get; set; }
    }
}
