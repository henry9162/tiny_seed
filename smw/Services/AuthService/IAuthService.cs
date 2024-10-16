using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SMW.Dtos.RequestDtos;
using SMW.Dtos.RequestDtos.Account;
using SMW.Dtos.RequestDtos.ResponseDtos;
using SMW.Dtos.ResponseDtos.Account;
using SMW.Dtos.ResponseDtos.UserManagement;
using SMW.Models;

namespace SMW.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<RegisterResponseDto>> Register(RegisterRequestDto user);
        Task<ServiceResponse<LoginResponseDto>> Login(LoginRequestDto loginData);
        Task<ServiceResponse<int>> VerifyEmail(string token);
        Task<ServiceResponse<LoginResponseDto>> SetPasswordResetToken(string email);
        Task<ServiceResponse<int>> ResetPassword(PasswordResetRequestDto passwordResetData);
        Task<ServiceResponse<int>> UpdateUser(UpdateUserRequestDto user);
        Task<ServiceResponse<int>> UpdateUserImage(IFormFile image);
        Task<ServiceResponse<ApplicationUser>> GetCurrentUser();
        string GetUserId();
    }
}