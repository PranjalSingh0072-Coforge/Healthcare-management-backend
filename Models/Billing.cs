namespace HealthcareManagement.Models
{
    public class Billing
    {

        public int Id { get; set; }
        public int PatientId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
