using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using SMW.Dtos.RequestDtos.AddressDto;
using SMW.Dtos.ResponseDtos.AddressDto;
using SMW.Dtos.ResponseDtos.UserManagement;
using SMW.Models;

namespace SMW.Services.AddressService
{
    public interface IAddressService
    {
        Task<ServiceResponse<List<StateResponseDto>>> GetAllStates();
        Task<ServiceResponse<List<LocalGovernmentResponseDto>>> GetLocalGovernments(int StateId);
        Task<ServiceResponse<List<AddressResponseDto>>> GetAllUserAddresses();
        Task<ServiceResponse<List<AddressResponseDto>>> AddAddress(AddressRequestDto address);
        Task<ServiceResponse<int>> UpdateAddress(PutAddressRequestDto address, int addressId);
        Task<ServiceResponse<int>> DeleteAddress(int addressId, string userId);
    }
}