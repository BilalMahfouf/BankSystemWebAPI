using Domain_BLL.DTOs.JobTitle;
using Domain_BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTitleController : ControllerBase
    {
        private readonly JobTitleService _jobTitleService;
        public JobTitleController(JobTitleService jobTitleService)
        {
            _jobTitleService= jobTitleService;
        }
        [HttpGet("All", Name = "GetAllJobTitlesAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ReadJobTitleDTO>>> GetAllJobTitlesAsync()
        {
            var jobTitles = await _jobTitleService.GetAllCountiesAsync();
            if(jobTitles is null || !jobTitles.Any())
            {
                return NotFound();
            }
            return Ok(jobTitles);
        }
    }
}
