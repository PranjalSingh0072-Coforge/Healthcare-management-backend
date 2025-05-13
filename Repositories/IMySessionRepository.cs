using HealthcareManagement.Models;

using System.Collections.Generic;
using System.Threading.Tasks;
namespace HealthcareManagement.Repositories{

public interface IMySessionRepository
{
    Task<IEnumerable<MySession>> GetMySessionsAsync();
    Task<MySession> AddMySessionAsync(MySession session);
}
}


 