using HealthcareManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareManagement.Repositories
{
    
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetBookingsAsync();
        Task<int> AddBookingAsync(Booking booking);
        Task<Booking> GetBookingByIdAsync(int bookingId);
    }
}
