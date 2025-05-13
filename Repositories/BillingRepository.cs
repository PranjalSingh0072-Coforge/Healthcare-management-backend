using Microsoft.Data.SqlClient; // Updated namespace
using Dapper;
using HealthcareManagement.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareManagement.Repositories
{
    public class BillingRepository : IBillingRepository
    {
        private readonly IConfiguration _configuration;

        public BillingRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection CreateConnection()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            return new SqlConnection(connectionString);
        }

        public async Task<IEnumerable<Billing>> GetBillingsAsync()
        {
            using (var connection = CreateConnection())
            {
                var sql = "SELECT * FROM Billings";
                return await connection.QueryAsync<Billing>(sql);
            }
        }

        public async Task<int> AddBillingAsync(Billing billing)
        {
            using (var connection = CreateConnection())
            {
                var sql = "INSERT INTO Billings (PatientId, Amount, Date) VALUES (@PatientId, @Amount, @Date)";
                return await connection.ExecuteAsync(sql, billing);
            }
        }

        public Task<Billing> GetBillingByIdAsync(int billingId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateBillingAsync(Billing billing)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteBillingAsync(int billingId)
        {
            throw new NotImplementedException();
        }
    }
}
