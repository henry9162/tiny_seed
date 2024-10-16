using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMW.Dtos.RequestDtos.StyleDto;
using SMW.Dtos.ResponseDtos.StyleDto;
using SMW.Models;

namespace SMW.Services.StyleService
{
    public interface IStyleService
    {
        Task<ServiceResponse<int>> Add(StyleRequestDto StyleData);
        Task<ServiceResponse<List<StyleResponseDto>>> GetAll();
        Task<ServiceResponse<StyleResponseDto>> GetById(int Id);
        Task<ServiceResponse<int>> Update(PutStyleRequestDto StyleData);
        Task<ServiceResponse<int>> Delete(int Id);
    }
}