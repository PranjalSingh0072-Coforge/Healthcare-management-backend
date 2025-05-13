using HealthcareManagement.Models;
using HealthcareManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HealthcareManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillingController : ControllerBase
    {
        private readonly IBillingRepository _billingRepository;

        public BillingController(IBillingRepository billingRepository)
        {
            _billingRepository = billingRepository;
        }

        [HttpGet]
      
        public async Task<IActionResult> GetBillings()
        {
            var billings = await _billingRepository.GetBillingsAsync();
            return Ok(billings);
        }

        [HttpPost]
     
        public async Task<ActionResult> AddBilling(Billing billing)
        {
           var result =  await _billingRepository.AddBillingAsync(billing);
            return Ok(result);
        }
    }
}
