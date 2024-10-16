using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMW.Dtos.RequestDtos;
using SMW.Dtos.RequestDtos.Account;
using SMW.Services.AuthService;
using SMW.Services.EmailService;

namespace SMW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;
        
        public AccountController(IAuthService authService, IEmailService emailService){
            this._authService = authService;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto postUser)
        {
            if(ModelState.IsValid){
                var response =  await _authService.Register(postUser);

                if(!response.Success)
                    return BadRequest(response);
                
                return Ok(response);
            }
            
            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto user)
        {
            if (ModelState.IsValid){
                var response = await _authService.Login(user);

                if(!response.Success)
                    return BadRequest(response);

                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpPost("VerifyEmail")]
        public async Task<IActionResult> Verify([FromBody] ConfirmEmailRequestDto request)
        {
            if (ModelState.IsValid){
                var response = await _authService.VerifyEmail(request.Token);

                if(!response.Success) 
                    return BadRequest(response);
                    
                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpPost("SetPasswordResetToken")]
        public async Task<IActionResult> SetPasswordResetToken([FromBody] ForgetPasswordResetDto request)
        {
            if (ModelState.IsValid){
                var response = await _authService.SetPasswordResetToken(request.Email);

                if(!response.Success)
                    return BadRequest(response);

                return Ok(response);   
            }
            
            return BadRequest(ModelState);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] PasswordResetRequestDto passwordResetData)
        {
            if (ModelState.IsValid){
                var response = await _authService.ResetPassword(passwordResetData);

                if(!response.Success)
                    return BadRequest(response);

                return Ok(response);   
            }
            
            return BadRequest(ModelState);
        }

        [HttpPut("UpdateUser"), Authorize]
        public async Task<IActionResult> UpdateUser(UpdateUserRequestDto user)
        {
            if (ModelState.IsValid)
            {
                var response = await _authService.UpdateUser(user);

                if(!response.Success)
                    return BadRequest(response);

                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpPost("UpdateUserImage"), Authorize]
        public async Task<IActionResult> UpdateUserImage(IFormFile image)
        {
            if (ModelState.IsValid){
                var response = await _authService.UpdateUserImage(image);

                if(!response.Success)
                    return BadRequest(response);

                return Ok(response);
            }   

            return BadRequest(ModelState);
        }

        [HttpGet("GetCurrentUser"), Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            var response = await _authService.GetCurrentUser();

            if (!response.Success){
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}