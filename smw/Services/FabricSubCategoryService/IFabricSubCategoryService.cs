using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMW.Dtos.RequestDtos.FabricCategoryDto;
using SMW.Dtos.RequestDtos.FabricSubCategoryDto;
using SMW.Dtos.ResponseDtos.FabricSubCategoryDto;
using SMW.Models;

namespace SMW.Services.FabricSubCategoryService
{
    public interface IFabricSubCategoryService
    {
        Task<ServiceResponse<int>> Add(FabricSubCategoryRequestDto FabricSubCategoryData);
        Task<ServiceResponse<List<FabricSubCategoryResponseDto>>> GetAll();
        Task<ServiceResponse<FabricSubCategoryResponseDto>> GetById(int Id);
        Task<ServiceResponse<int>> Update(PutFabricSubCategoryRequestDto FabricSubCategoryData);   
        Task<ServiceResponse<int>> Delete(int Id);
    }
}