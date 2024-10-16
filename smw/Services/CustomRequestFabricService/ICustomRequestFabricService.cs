using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMW.Dtos.RequestDtos.CustomFabricDto;
using SMW.Dtos.ResponseDtos.CustomFabricDto;
using SMW.Models;

namespace SMW.Services.CustomRequestFabricService
{
    public interface ICustomRequestFabricService
    {
        Task<ServiceResponse<int>> Add(List<CustomFabricRequestDto> CustomRequestFabricData);
        Task<ServiceResponse<List<CustomFabricResponseDto>>> GetAll();
        Task<ServiceResponse<CustomFabricResponseDto>> GetById(int Id);
        Task<ServiceResponse<int>> Update(PutCustomFabricRequestDto CustomRequestFabricData);   
        Task<ServiceResponse<int>> Delete(int Id);
    }
}