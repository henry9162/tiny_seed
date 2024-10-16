using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMW.Dtos.RequestDtos.StyleCategory;
using SMW.Dtos.ResponseDtos.StyleCategoryDto;
using SMW.Models;

namespace SMW.Services.StyleCategoryService
{
    public interface IStyleCategoryService
    {
        Task<ServiceResponse<int>> Add(StyleCategoryRequestDto category);
        Task<ServiceResponse<List<StyleCategoryResponseDto>>> GetAll();
        Task<ServiceResponse<StyleCategoryResponseDto>> GetById(int id);
        Task<ServiceResponse<int>> Update(PutStyleCategoryRequestDto category);
        Task<ServiceResponse<int>> Delete(int id);
    }
}