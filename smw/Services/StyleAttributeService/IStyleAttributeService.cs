using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using SMW.Dtos.RequestDtos.StyleAttributeDto;
using SMW.Dtos.ResponseDtos.StyleAttributeDto;
using SMW.Models;

namespace SMW.Services.StyleAttributeService
{
    public interface IStyleAttributeService
    {
        Task<ServiceResponse<int>> Add(StyleAttributeRequestDto styleAttributeData);
        Task<ServiceResponse<List<StyleAttributeResponseDto>>> GetAll();
        Task<ServiceResponse<StyleAttributeResponseDto>> GetById(int Id);
        Task<ServiceResponse<int>> Update(PutStyleAttributeRequestDto styleAttributeData);
        Task<ServiceResponse<int>> Delete(int Id);
    }
}