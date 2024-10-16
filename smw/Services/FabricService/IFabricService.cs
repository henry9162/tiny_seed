using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMW.Dtos.RequestDtos.FabricDto;
using SMW.Dtos.ResponseDtos.FabricDto;
using SMW.Models;

namespace SMW.Services.FabricService
{
    public interface IFabricService
    {
        Task<ServiceResponse<int>> Add(FabricRequestDto FabricData);
        Task<ServiceResponse<List<FabricResponseDto>>> GetAll();
        Task<ServiceResponse<FabricResponseDto>> GetById(int Id);
        Task<ServiceResponse<int>> Update(PutFabricRequestDto FabricData);
        Task<ServiceResponse<int>> Delete(int Id);
    }
}