using HealthcareManagement.Models;
using HealthcareManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HealthcareManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MySessionController : ControllerBase
    {
        private readonly IMySessionRepository _mySessionRepository;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public MySessionController(IMySessionRepository mySessionRepository)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
            _mySessionRepository = mySessionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMySessions()
        {
            var mySessions = await _mySessionRepository.GetMySessionsAsync();
            return Ok(mySessions);
        }

        [HttpPost]
        public async Task<IActionResult> AddMySessions([FromBody] MySession mySessions)
        {
            if (mySessions == null)
            {
                return BadRequest("mySessions is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            var result = await _mySessionRepository.AddMySessionAsync(mySessions);
            return CreatedAtAction(nameof(GetMySessions), new { id = result.Id }, result);
        }
    }
}
