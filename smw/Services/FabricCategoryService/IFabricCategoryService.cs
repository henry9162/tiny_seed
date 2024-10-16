using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMW.Dtos.RequestDtos.FabricCategoryDto;
using SMW.Dtos.ResponseDtos.FabricCategoryDto;
using SMW.Models;

namespace SMW.Services.FabricCategoryService
{
    public interface IFabricCategoryService
    {
        Task<ServiceResponse<int>> Add(FabricCategoryRequestDto FabricCategoryData);
        Task<ServiceResponse<List<FabricCategoryResponseDto>>> GetAll();
        Task<ServiceResponse<FabricCategoryResponseDto>> GetById(int Id);
        Task<ServiceResponse<int>> Update(PutFabricCategoryRequestDto FabricData);   
        Task<ServiceResponse<int>> Delete(int Id);
    }
}