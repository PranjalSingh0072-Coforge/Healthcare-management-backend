using Microsoft.Data.SqlClient;
using Dapper;
using HealthcareManagement.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareManagement.Repositories
{
    public class PatientRepository(IConfiguration configuration) : IPatientRepository
    {
        private readonly IConfiguration _configuration = configuration;

        private SqlConnection CreateConnection()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            return new SqlConnection(connectionString);
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            using (var connection = CreateConnection())
            {
                var sql = "SELECT * FROM Patients";
                return await connection.QueryAsync<Patient>(sql);
            }
        }

        public async Task<int> AddPatientAsync(Patient patient)
        {
            using var connection = CreateConnection();
            var sql = "INSERT INTO Patients (Name, Age, Gender, MedicalHistory) VALUES (@Name, @Age, @Gender, @MedicalHistory); SELECT CAST(SCOPE_IDENTITY() as int)";
            return await connection.ExecuteScalarAsync<int>(sql, patient);
        }
    }

    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetPatientsAsync();
        Task<int> AddPatientAsync(Patient patient);
    }
}
