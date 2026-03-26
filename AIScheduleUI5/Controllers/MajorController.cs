using AIScheduleUI5.BLL.DTOs;
using AIScheduleUI5.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AIScheduleUI5.Controllers
{
    [ApiController]
    [Route("api/majors")]
    public class MajorController : ControllerBase
    {
        private readonly IMajorService _majorService;

        public MajorController(IMajorService majorService)
        {
            _majorService = majorService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByUniId( Guid id)
        {
            try
            {
                if (id == null)
                    return NotFound();
                List<MajorDto> majors = await _majorService.GetByUniversityIdAsync(id);
                return Ok(majors);
            }
            catch (Exception ex)
            {
                {
                    return BadRequest(ex.Message);
                }

            }
        }
    }
}
