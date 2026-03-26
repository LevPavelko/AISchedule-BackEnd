using System.Data;
using AIScheduleUI5.BLL.DTOs;
using AIScheduleUI5.BLL.Interfaces;
using AIScheduleUI5.BLL.Services;
using AIScheduleUI5.Models;
using Microsoft.AspNetCore.Mvc;

namespace AIScheduleUI5.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ISecureService _secureService;
        public UserController (IUserService userService, ISecureService secureService)
        {
            _userService = userService;
            _secureService = secureService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                UserDto user = await _userService.GetByEmailAsync(model.Email);
                if (user == null)
                    return BadRequest();
                var decryptedPassword = _secureService.DecryptPassword(user.Password);
                if (!model.Password.Equals(decryptedPassword))
                    return new JsonResult(new { message = "Wrong password or email!" }) { StatusCode = 403 };

                string jwtToken = _secureService.GenerateJwtToken(user);
                var encryptedId = _secureService.EncryptSessionGuid(user.Id);
                return Ok(new { message = "Authenticateed", jwt = jwtToken,id = encryptedId });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUpModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                bool isUserExist = await _userService.UserExistsByEmailAsync(model.Email);
                if (isUserExist)
                    return new JsonResult(new { message = "User already exist!" }) { StatusCode = 403 };
                var encryptedPassword = _secureService.EncryptPassword(model.Password);
                UserDto user = new UserDto
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Email = model.Email,
                    Password = encryptedPassword
                };
                await _userService.CreateAsync(user);
                string jwtToken = _secureService.GenerateJwtToken(user);
                var encryptedId = _secureService.EncryptSessionGuid(user.Id);
                return Ok(new { message = "Authenticateed", jwt = jwtToken, id = encryptedId});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
