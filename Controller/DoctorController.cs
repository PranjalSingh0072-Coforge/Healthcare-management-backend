using HealthcareManagement.Models;
using HealthcareManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HealthcareManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await _doctorRepository.GetDoctorsAsync();
            return Ok(doctors);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddDoctor([FromBody] Doctor doctor)
        {
            if (doctor == null)
            {
                return BadRequest("Doctor is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            var result = await _doctorRepository.AddDoctorAsync(doctor);
            return CreatedAtAction(nameof(GetDoctors), new { id = result }, result);
        }


        private object Getdoctors()
        {
            throw new NotImplementedException();
        }
    }
}
