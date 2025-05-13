using HealthcareManagement.Models;

namespace HealthcareManagement.Repositories
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetPatientAsync();
        Task<int> AddPatientAsync(Patient patient);
        Task<Patient> GetPatientByIdAsync(int patientId);
        
    }
}
