using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMW.Dtos.RequestDtos.StyleSubCategoryDto;
using SMW.Dtos.ResponseDtos.StyleSubCategoryDto;
using SMW.Models;

namespace SMW.Services.StyleSubCategoryService
{
    public interface IStyleSubCategoryService
    {
        Task<ServiceResponse<int>> Add(StyleSubCategoryRequestDto category);
        Task<ServiceResponse<List<StyleSubCategoryResponseDto>>> GetAll();
        Task<ServiceResponse<StyleSubCategoryResponseDto>> GetById(int id);
        Task<ServiceResponse<int>> Update(PutStyleSubCategoryRequestDto category);
        Task<ServiceResponse<int>> Delete(int id);
    }
}