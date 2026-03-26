using AIScheduleUI5.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AIScheduleUI5.Controllers
{
    [ApiController]
    [Route("api/universities")]
    public class UniversityController : ControllerBase
    {
        private readonly IUniversityService _universityService;

        public UniversityController(IUniversityService universityService)
        {
            _universityService = universityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var unis = await _universityService.GetAllAsync();
                if (unis == null)
                    return NotFound();
                return Ok(unis);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
