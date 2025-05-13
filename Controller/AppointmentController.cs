using HealthcareManagement.Models;
using HealthcareManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HealthcareManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentController(IAppointmentRepository appointmentRepositories)
        {
            _appointmentRepository = appointmentRepositories;
        }

        [HttpGet]
      
        public async Task<IActionResult> GetAppointments()
        {
            var appointments = await _appointmentRepository.GetAppointmentsAsync();
            return Ok(appointments);
        }

        [HttpPost]
     
        public async Task<ActionResult> AddAppointment(Appointment appointment)
        {
            var result =   await _appointmentRepository.AddAppointmentAsync(appointment);
            return Ok(result);
        }
    }
}
