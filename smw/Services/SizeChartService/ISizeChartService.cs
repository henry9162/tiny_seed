using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMW.Dtos.RequestDtos.SizeChartDto;
using SMW.Dtos.ResponseDtos.SizeChartDto;
using SMW.Models;

namespace SMW.Services.SizeChartService
{
    public interface ISizeChartService
    {
        Task<ServiceResponse<int>> Add(SizeChartRequestDto SizeChartData);
        Task<ServiceResponse<List<SizeChartResponseDto>>> GetAll();
        Task<ServiceResponse<SizeChartResponseDto>> GetById(int Id);
        Task<ServiceResponse<int>> Update(PutSizeChartRequestDto SizeChartData);   
        Task<ServiceResponse<int>> Delete(int Id);
    }
}