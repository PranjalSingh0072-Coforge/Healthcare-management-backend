using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using HealthcareManagement.Models;
using Microsoft.Extensions.Configuration;

public class ViewRepository(IConfiguration configuration) : IViewRepository
{
#pragma warning disable CS8601 // Possible null reference assignment.
    private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection");
#pragma warning restore CS8601 // Possible null reference assignment.

    [Obsolete]
    public async Task AddViewAsync(ViewModel viewModel)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand("AddView", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@DoctorId", viewModel.DoctorId);
            command.Parameters.AddWithValue("@Telephone", viewModel.Telephone ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@NIC", viewModel.NIC ?? (object)DBNull.Value);

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }
    }

    [Obsolete]
    public async Task<IEnumerable<ViewModel>> GetViewModelsAsync()
    {
        var viewModels = new List<ViewModel>();

        using (var connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand("SELECT * FROM Views", connection);
            await connection.OpenAsync();

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var viewModel = new ViewModel
                    {
                        DoctorId = reader.GetInt32(reader.GetOrdinal("Id")),
                        Telephone = reader.IsDBNull(reader.GetOrdinal("Telephone")) ? null : reader.GetString(reader.GetOrdinal("Telephone")),
                        NIC = reader.IsDBNull(reader.GetOrdinal("NIC")) ? null : reader.GetString(reader.GetOrdinal("NIC"))
                    };
                    viewModels.Add(viewModel);
                }
            }
        }

        return viewModels;
    }

    public Task GetViewsAsync()
    {
        throw new NotImplementedException();
    }
}

public interface IViewRepository
{
    Task AddViewAsync(ViewModel viewModel);
    Task<IEnumerable<ViewModel>> GetViewModelsAsync();
    Task GetViewsAsync();
}
