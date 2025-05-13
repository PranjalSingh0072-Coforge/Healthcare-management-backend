using Microsoft.Data.SqlClient;
using Dapper;
using HealthcareManagement.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareManagement.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IConfiguration _configuration;

        public BookingRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection CreateConnection()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            return new SqlConnection(connectionString);
        }

        public async Task<IEnumerable<Booking>> GetBookingsAsync()
        {
            using (var connection = CreateConnection())
            {
                var sql = "SELECT * FROM Bookings";
                return await connection.QueryAsync<Booking>(sql);
            }
        }

        public async Task<int> AddBookingAsync(Booking booking)
        {
            using var connection = CreateConnection();
            var sql = "INSERT INTO Bookings (Id,Name, Age, Gender, Disease, DoctorName, Date) VALUES ( @Id, @Name, @Age, @Gender, @Disease, @DoctorName, @Date); SELECT CAST(SCOPE_IDENTITY() as int)";
            return await connection.ExecuteScalarAsync<int>(sql, booking);
        }
    }

    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetBookingsAsync();
        Task<int> AddBookingAsync(Booking booking);
    }
}
