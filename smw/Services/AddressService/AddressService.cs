using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMW.Data;
using SMW.Dtos.RequestDtos.AddressDto;
using SMW.Dtos.ResponseDtos.AddressDto;
using SMW.Dtos.ResponseDtos.UserManagement;
using SMW.Models;
using SMW.Services.AuthService;
using SMW.Utilities;

namespace SMW.Services.AddressService
{
    public class AddressService : IAddressService
    {
        private readonly DatabaseContext _context;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        public AddressService(DatabaseContext context, IAuthService authService, IMapper mapper)
        {
            this._context = context;
            this._authService = authService;
            this._mapper = mapper;
        }
        public async Task<ServiceResponse<List<AddressResponseDto>>> AddAddress(AddressRequestDto postAddressData)
        {
            var response = new ServiceResponse<List<AddressResponseDto>>();

            try
            {
                var address = _mapper.Map<Address>(postAddressData);

                _context.Addresses.Add(address);
                await _context.SaveChangesAsync();

                response.Data = await _context.Addresses
                    .Where(x => x.UserId == address.UserId)
                    .Include(x => x.State)
                    .Include(x => x.LocalGovernment)
                    .Select(x => _mapper.Map<AddressResponseDto>(x))
                    .ToListAsync();

                return response;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occured: {ex.Message}";
                return response;
            }
        }

        public async Task<ServiceResponse<List<AddressResponseDto>>> GetAllUserAddresses()
        {
            var response = new ServiceResponse<List<AddressResponseDto>>();

            try
            {
                var user =  await _authService.GetCurrentUser();

                if (!user.Success){
                    response.Success = false;
                    response.Message = "User not logged in";
                    return response;
                }

                response.Data = await _context.Addresses
                    .Include(x => x.State)
                    .Include(x => x.LocalGovernment)
                    .Where(x => x.UserId == user.Data!.Id)
                    .Select(x => _mapper.Map<AddressResponseDto>(x))
                    .ToListAsync();

                return response;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occured: {ex.Message}";
                return response;
            }
        }

        public async Task<ServiceResponse<List<StateResponseDto>>> GetAllStates()
        {
            var response = new ServiceResponse<List<StateResponseDto>>();

            try
            {
                response.Data = await _context.States
                    .Select(x => _mapper.Map<StateResponseDto>(x))
                    .ToListAsync();

                if (response.Data.Count < 1){
                    response.Success = false;
                    response.Message = "No states found";
                    return response;
                }
                
                return response;
            } 
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occured: {ex.Message}";
                return response;
            }
        }

        public async Task<ServiceResponse<List<LocalGovernmentResponseDto>>> GetLocalGovernments(int StateId)
        {
            var response = new ServiceResponse<List<LocalGovernmentResponseDto>>();

            try 
            {
                response.Data = await _context.Local_Governments
                    .Where(x => x.StateId.Equals(StateId))
                    .Select(x => _mapper.Map<LocalGovernmentResponseDto>(x))
                    .ToListAsync();

                if (response.Data.Count < 1){
                    response.Success = false;
                    response.Message = "No local governments found";
                    return response;
                }

                return response; 
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occured: {ex.Message}";
                return response;
            }
        }

        public async Task<ServiceResponse<int>> UpdateAddress(PutAddressRequestDto putAddress, int putAddressId)
        {
            var response = new ServiceResponse<int>();

            try
            {
                var userId =  _authService.GetUserId();

                if (!string.IsNullOrEmpty(userId) && !userId.Equals(putAddress.UserId)){
                    response.Success = false;
                    response.Message = "Unauthorized operation";
                    return response;
                }

                var address = _mapper.Map<Address>(putAddress);

                _context.Entry(address).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return response;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occured: {ex.Message}";
                return response;
            }
        }

        public async Task<ServiceResponse<int>> DeleteAddress(int addressId, string userId)
        {
            var response = new ServiceResponse<int>();

            try
            {
                var loggedUserId =  _authService.GetUserId();

                if (!string.IsNullOrEmpty(loggedUserId) && !loggedUserId.Equals(userId)){
                    response.Success = false;
                    response.Message = "Unauthorized operation"; 
                    return response;
                }

                var address = await _context.Addresses.Where(x => x.Id == addressId).FirstOrDefaultAsync();

                if(address is null){
                    response.Success = false;
                    response.Message = "Record not found";
                    return response;
                }

                _context.Addresses.Remove(address!);
                await _context.SaveChangesAsync();

                return response;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occured: {ex.Message}";
                return response;
            }
        }
    }
}