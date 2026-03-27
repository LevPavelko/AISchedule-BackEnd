using System.Net;
using AIScheduleUI5.BLL.DTOs;
using AIScheduleUI5.BLL.Interfaces;
using AIScheduleUI5.Models;
using Microsoft.AspNetCore.Mvc;

namespace AIScheduleUI5.Controllers
{
    [ApiController]
    [Route("api/studydata")]
    public class StudyDataController : ControllerBase
    {
        private readonly IStudyDataService _studyDataService;
        private readonly ISecureService _secureService;

        public StudyDataController(IStudyDataService studyDataService, ISecureService secureService)
        {
            _studyDataService = studyDataService;
            _secureService = secureService;
        }

        [HttpPost]
        public async Task<IActionResult> AddStudyData([FromBody] StudyDataModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var urlDecoded = WebUtility.UrlDecode(model.UserId);
                Guid decryptedUserId = _secureService.DecryptSessionGuid(urlDecoded);
                if (decryptedUserId == null)
                {
                    return BadRequest("Invalid user ID");
                }
                StudyDataDto dto = new StudyDataDto
                {
                    UniId = model.UniId,
                    MajorId = model.MajorId,
                    UserId = decryptedUserId,
                    Semester = model.Semester
                };
                await _studyDataService.CreateAsync(dto);
                return Ok(new { message = "Study data added successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("getByUserId/{userId}")]
        public async Task<IActionResult> GetStudyDataByUserId(string userId)
        {
            try
            {
                var urlDecoded = Uri.UnescapeDataString(userId);
                Guid decryptedUserId = _secureService.DecryptSessionGuid(urlDecoded);
                if (decryptedUserId == null)
                {
                    return BadRequest("Invalid user ID");
                }
                StudyDataDto studyData = await _studyDataService.GetStudyDataByUserId(decryptedUserId);
                if (studyData == null)
                {
                    return NotFound("Study data not found for the given user ID");
                }
                return Ok(studyData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}