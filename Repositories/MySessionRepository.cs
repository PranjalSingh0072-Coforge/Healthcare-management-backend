using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using HealthcareManagement.Repositories;
using Microsoft.Extensions.Configuration;

public class MySessionRepository(IConfiguration configuration) : IMySessionRepository
{
#pragma warning disable CS8601 // Possible null reference assignment.
    private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection");
#pragma warning restore CS8601 // Possible null reference assignment.

    [Obsolete]
    private IDbConnection Connection => new SqlConnection(_connectionString);

    [Obsolete]
    public async Task<IEnumerable<MySession>> GetMySessionsAsync()
    {
        using (var dbConnection = Connection)
        {
            dbConnection.Open();
            return await dbConnection.QueryAsync<MySession>("SELECT * FROM MySessions");
        }
    }

    [Obsolete]
    public async Task<MySession> AddMySessionAsync(MySession session)
    {
        using (var dbConnection = Connection)
        {
            dbConnection.Open();
            var sql = "INSERT INTO MySessions (SessionTitle, ScheduledTime, BookingList, Events) VALUES (@SessionTitle, @ScheduledTime, @BookingList, @Events); SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = await dbConnection.QuerySingleAsync<int>(sql, session);
            session.Id = id;
            return session;
        }
    }
}
