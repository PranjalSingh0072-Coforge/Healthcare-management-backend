using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthcareManagement.Models;

namespace HealthcareManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewController : ControllerBase
    {
        private readonly IViewRepository _viewRepository;

        public ViewController(IViewRepository viewRepository)
        {
            _viewRepository = viewRepository;
        }

        // POST: api/View
        [HttpPost]
        public async Task<IActionResult> AddView([FromBody] ViewModel viewModel)
        {
            if (viewModel == null)
            {
                return BadRequest();
            }

            await _viewRepository.AddViewAsync(viewModel);
            return Ok();
        }

        // GET: api/View
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewModel>>> GetViewModels()
        {
            var viewModels = await _viewRepository.GetViewModelsAsync();
            return Ok(viewModels);
        }
    }
}
