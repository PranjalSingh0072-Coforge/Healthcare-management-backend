using HealthcareManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareManagement.Repositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAppointmentsAsync();
        Task<int> AddAppointmentAsync(Appointment appointment);
        Task<Appointment> GetAppointmentByIdAsync(int appointmentId);
        Task<int> UpdateAppointmentAsync(Appointment appointment);
        Task<int> DeleteAppointmentAsync(int appointmentId);
    }
}
