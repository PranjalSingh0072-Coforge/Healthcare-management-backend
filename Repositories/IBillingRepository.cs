using HealthcareManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareManagement.Repositories
{
    public interface IBillingRepository
    {
        Task<IEnumerable<Billing>> GetBillingsAsync();
        Task<int> AddBillingAsync(Billing billing);
        Task<Billing> GetBillingByIdAsync(int billingId);
        Task<int> UpdateBillingAsync(Billing billing);
        Task<int> DeleteBillingAsync(int billingId);
    }
}
