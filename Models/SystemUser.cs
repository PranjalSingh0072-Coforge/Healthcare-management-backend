using Microsoft.AspNetCore.Identity;

namespace HealthcareManagement.Models {
    public class SystemUser : IdentityUser {
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
