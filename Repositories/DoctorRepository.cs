using Microsoft.Data.SqlClient;
using Dapper;
using HealthcareManagement.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareManagement.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly IConfiguration _configuration;

        public DoctorRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection CreateConnection()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            return new SqlConnection(connectionString);
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
        {
            using (var connection = CreateConnection())
            {
                var sql = "SELECT * FROM Doctors";
                return await connection.QueryAsync<Doctor>(sql);
            }
        }

        public async Task<int> AddDoctorAsync(Doctor doctor)
        {
            using var connection = CreateConnection();
            var sql = "INSERT INTO Doctors (DoctorName, Email, Specialties, Events) VALUES ( @DoctorName, @Email, @Specialties, @Events); SELECT CAST(SCOPE_IDENTITY() as int)";
            return await connection.ExecuteScalarAsync<int>(sql, doctor);
        }

        public Task AdddoctorAsync(Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }

    public interface IDoctorRepository
    {
                Task<IEnumerable<Doctor>> GetDoctorsAsync();
        Task<int> AddDoctorAsync(Doctor doctor);
        Task AdddoctorAsync(Doctor doctor);
    }

  
}
