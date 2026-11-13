using BusinessLogic.Services.Interfaces;
using DataAccess.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Salla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAuthService _authenticationService;
        public AccountsController(
            IAuthService authenticationService
            )
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register([FromBody] UserRegisterDTO request)
        {
            var result = _authenticationService.RegisterAsync(request);
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login([FromBody] UserLoginDTO request)
        {
            var result = await _authenticationService.LoginAsync(request);
            return Ok(result);
        }
        [HttpGet("ConfirmedEmail")]
        public async Task<ActionResult<string>> ConfirmEmail([FromQuery] string token, [FromQuery] string userId)
        {
            var result = await _authenticationService.ConfirmEmail(token, userId);
            return Ok(result);
        }
        [HttpPost("ForgotPassword")]
        public async Task<ActionResult<string>> ForgotPassword([FromBody] ForgetPasswordDTO request)
        {
            var result = await _authenticationService.ForgotPasswordAsync(request);
            return Ok(result);

        }
        [HttpPatch("ResetPassword")]
        public async Task<ActionResult<string>> ResetPassword([FromBody] ResetPasswordDTO request)
        {
            var result = await _authenticationService.ResetPasswordAsync(request);
            return Ok(result);

        }
    }
}
