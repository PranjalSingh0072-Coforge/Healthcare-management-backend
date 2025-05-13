using Microsoft.Data.SqlClient; // Updated namespace
using Dapper;
using HealthcareManagement.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareManagement.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly IConfiguration _configuration;

        public AppointmentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection CreateConnection()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            return new SqlConnection(connectionString);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsAsync()
        {
            using (var connection = CreateConnection())
            {
                var sql = "SELECT * FROM Appointments";
                return await connection.QueryAsync<Appointment>(sql);
            }
        }

        public async Task<int> AddAppointmentAsync(Appointment appointment)
        {
            using (var connection = CreateConnection())
            {
                var sql = "INSERT INTO Appointments (PatientId, Date, Reason) VALUES (@PatientId, @Date, @Reason)";
                return await connection.ExecuteAsync(sql, appointment);
            }
        }

        public Task<Appointment> GetAppointmentByIdAsync(int appointmentId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAppointmentAsync(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAppointmentAsync(int appointmentId)
        {
            throw new NotImplementedException();
        }
    }
}
