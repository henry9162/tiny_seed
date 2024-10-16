using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SMW.Data;
using SMW.Dtos.RequestDtos;
using SMW.Dtos.RequestDtos.Account;
using SMW.Dtos.RequestDtos.AddressDto;
using SMW.Dtos.RequestDtos.Email;
using SMW.Dtos.RequestDtos.ResponseDtos;
using SMW.Dtos.ResponseDtos.Account;
using SMW.Models;
using SMW.Services.AddressService;
using SMW.Services.EmailService;
using SMW.Services.StorageService;
using SMW.Utilities;

namespace SMW.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;
        private readonly IEmailService _emailService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;

        public AuthService(DatabaseContext context, 
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            IConfiguration config, 
            IEmailService emailService, 
            IHttpContextAccessor httpContextAccessor, 
            IStorageService storageService,
            IMapper mapper)
        {
            this._context = context;
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._config = config;
            this._emailService = emailService;
            this._httpContextAccessor = httpContextAccessor;
            this._storageService = storageService;
            this._mapper = mapper;
        }

        public string GetUserId() => _httpContextAccessor.HttpContext!.User
            .FindFirstValue(ClaimTypes.NameIdentifier)!;

        public async Task<ServiceResponse<LoginResponseDto>> Login(LoginRequestDto loginData)
        {
            var response = new ServiceResponse<LoginResponseDto>();

            try
            {
                if (!await UserExist(loginData.Email!)){
                    response.Success = false;
                    response.Message = "Your record does not exist, kindly register";
                    return response;
                }

                var user = await _userManager.FindByEmailAsync(loginData.Email!);

                if(!await ValidatePassword(user!, loginData.Password!)){
                    response.Success = false;
                    response.Message = "Could not sign you in, kindly check credentials and try again";
                    return response;
                }
                    
                response.Data = new LoginResponseDto {
                    FirstName = user!.FirstName,
                    LastName = user!.LastName,
                    Email = user!.Email,
                    Token = await CreateToken(user!)
                };

                return response;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occured: {ex.Message}";
                return response;
            }
        }

        public async Task<ServiceResponse<RegisterResponseDto>> Register(RegisterRequestDto postUser)
        {
            var response = new ServiceResponse<RegisterResponseDto>();
            
            try
            {
                if (await UserExist(postUser.Email!)){
                    response.Success = false;
                    response.Message = "You are already registered, kindly proceed to login";
                    return response;
                }

                var user = _mapper.Map<ApplicationUser>(postUser);
                var result = await _userManager.CreateAsync(user, postUser.Password!);

                if (!result.Succeeded){
                    response.Success = false;
                    response.Message = "Unable to register you as a user, kindly check credentials and try again";   
                    return response;
                }

                var userRole = Enum.GetName(typeof(Role), postUser.UserType);

                if (userRole is not null && !await _roleManager.RoleExistsAsync(userRole)){
                    await _roleManager.CreateAsync(new IdentityRole(userRole));
                    await _userManager.AddToRoleAsync(user, userRole);
                } else
                    await _userManager.AddToRoleAsync(user, userRole!);

                EmailRequestDto emailData = new EmailRequestDto{
                    To = user.Email!,
                    Subject = "SMW Email Confirmation",
                    Body = $"<h2>https://sewMyWare.com/{user.EmailConfirmationToken}</h2>"
                };

                 //Add this call to queue
                _ = _emailService.SendEmail(emailData);

                response.Data = await _context.Users
                    .Where(x => x.Email! == user.Email)
                    .Select(x => _mapper.Map<RegisterResponseDto>(x))
                    .FirstOrDefaultAsync();

                return response;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = $"An error ocurred: {ex.Message}";
                return response;
            }
        }

        public async Task<ServiceResponse<int>> VerifyEmail(string token)
        {
            var response = new ServiceResponse<int>();

            try 
            {
                var user = await _context.Users.Where(x => x.EmailConfirmationToken == token).FirstOrDefaultAsync();

                if (user is null){
                    response.Success = false;
                    response.Message = "User does not exist, kindly register";
                    return response;
                }

                if (user.EmailConfirmed){
                    response.Success = false;
                    response.Message = "User is already confirmed";
                    return response;
                }

                user.EmailConfirmed = true;
                user.EmailConfirmationToken = string.Empty;
                user.EmailConfirmedAt = DateTime.Now;
                await _userManager.UpdateAsync(user);
                
                return response;
            } 
            catch (Exception ex) 
            {
                response.Success = false;
                response.Message = $"An error occured: {ex.Message}";
                return response;
            }
        }

        public async Task<ServiceResponse<LoginResponseDto>> SetPasswordResetToken(string email)
        {
            var response = new ServiceResponse<LoginResponseDto>();

            try
            {
                if (!await UserExist(email)){
                    response.Success = false;
                    response.Message = "User does not exist";
                    return response;
                }

                var user = await _userManager.FindByEmailAsync(email);

                user!.PasswordResetToken = RandomString.GenerateRandomString(40);
                user.PasswordResetExpiry = DateTime.Now.AddDays(1);
                await _userManager.UpdateAsync(user);

                // Send registration email
                EmailRequestDto emailData = new EmailRequestDto{
                    To = user!.Email!,
                    Subject = "SMW Password Reset",
                    Body = $"<h2>https://sewMyWare.com/{user.PasswordResetToken}</h2>"
                };

                _ = _emailService.SendEmail(emailData);

                response.Data = new LoginResponseDto{
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                };

                return response;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ServiceResponse<int>> ResetPassword(PasswordResetRequestDto passwordResetData)
        {
            var response = new ServiceResponse<int>();

            try 
            {
                var user = await _context.Users.Where(x => x.PasswordResetToken == passwordResetData.Token).FirstOrDefaultAsync();

                if (user is null){
                    response.Success = false;
                    response.Message = "Invalid token";
                    return response;
                } 

                if (user.PasswordResetExpiry < DateTime.Now){
                    response.Success = false;
                    response.Message = "Password reset link is expired";
                    return response;
                }

                var passwordChange = await _userManager.ChangePasswordAsync(user, passwordResetData.CurrentPassword!, passwordResetData.NewPassword!);

                if (!passwordChange.Succeeded){
                    response.Success = false;
                    response.Message = "Unable to change password, kindly check your password and retry";
                    return response;
                }

                user.PasswordResetToken = string.Empty;
                user.PasswordResetAt = DateTime.Now;

                await _userManager.UpdateAsync(user);
                
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occured while reseting password: {ex.Message}";
                return response;
            }
        }

        public async Task<ServiceResponse<int>> UpdateUser(UpdateUserRequestDto postUser)
        {
            var response = new ServiceResponse<int>();

            try
            {
                var userData = await GetCurrentUser();
                var applicationUser = userData.Data;

                if (applicationUser is null || string.IsNullOrEmpty(applicationUser.Email)){
                    response.Success = false;
                    response.Message = "User is not found";
                    return response;
                }

                applicationUser.FirstName = postUser.FirstName;
                applicationUser.LastName = postUser.LastName;
                applicationUser.Email = postUser.Email;
                applicationUser.UserName = postUser.UserName;
                applicationUser.PhoneNumber = postUser.PhoneNumber;

                var resp = await _userManager.UpdateAsync(applicationUser);

                if (!resp.Succeeded){
                    response.Success = false;
                    response.Message = $"Update failed: {GetErrors.IdentityErrors(resp.Errors)}";
                    return response;
                }

                return response;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occured: {ex.Message}";
                return response;
            }
        }

        public async Task<ServiceResponse<ApplicationUser>> GetCurrentUser()
        {
            var response = new ServiceResponse<ApplicationUser>();
            try
            {
                var userId = _httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (string.IsNullOrEmpty(userId)){
                    response.Success = false;
                    response.Message = "No current user found";
                    return response;
                }

                var user = await _userManager.FindByIdAsync(userId!);

                response.Data = user;

                return response;
            } 
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occured: {ex.Message}";
                return response;
            }
        }

        public async Task<ServiceResponse<int>> UpdateUserImage(IFormFile image)
        {
            var response = new ServiceResponse<int>();

            try
            {
                var userData = await GetCurrentUser();
                var user = userData.Data;

                var fileUpload = await _storageService.UploadFormFile(image, "Users", user!.ImagePath!);

                if(fileUpload is null || string.IsNullOrEmpty(fileUpload.FilePath)){
                    response.Success = false;
                    response.Message = "Image could not be uploaded, please check image size and type, then try again";
                    return response;
                }

                user!.ImagePath = fileUpload.FilePath;
                user.ImageName = fileUpload.FileName;
                user.OriginalImageName = fileUpload.OriginalFileName;

                await _userManager.UpdateAsync(user);

                return response;
            } 
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occured: {ex.Message}";
                return response;
            }
        }

        public async Task<bool> UserExist(string email)
        {
            if (await _context.Users.AnyAsync(x => x.Email!.ToLower() == email.ToLower()))
                return true;
            else
                return false;
        }

        public async void AssignRole(ApplicationUser user, string role){
            if(role is not null && !await _roleManager.RoleExistsAsync(role)){
                await _roleManager.CreateAsync(new IdentityRole(role));
                await _userManager.AddToRoleAsync(user, role);
            } else
                await _userManager.AddToRoleAsync(user, role!);
        }

        public async Task<bool> ValidatePassword(ApplicationUser user, string password){
            if(user is not null && await _userManager.CheckPasswordAsync(user, password))
                return true;
            else
                return false;
        }

        public async Task<string> CreateToken(ApplicationUser user){
            var userRoles = await _userManager.GetRolesAsync(user); 

            var claims = new List<Claim>{
                    new Claim(ClaimTypes.NameIdentifier, user.Id!),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

            foreach (var role in userRoles){
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenIdentifier = _config.GetSection("AppSettings:Token").Value;

            if (tokenIdentifier is null){
                throw new Exception("Token identifier is null");
            }

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(tokenIdentifier));

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}