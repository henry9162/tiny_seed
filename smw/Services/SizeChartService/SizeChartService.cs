using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMW.Data;
using SMW.Dtos.RequestDtos.SizeChartDto;
using SMW.Dtos.ResponseDtos.SizeChartDto;
using SMW.Models;

namespace SMW.Services.SizeChartService
{
    public class SizeChartService : ISizeChartService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public SizeChartService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<int>> Add(SizeChartRequestDto SizeChartData)
        {
            var response = new ServiceResponse<int>();

            try
            {
                var sizeChart = _mapper.Map<SizeChart>(SizeChartData);
                
                _context.SizeCharts.Add(sizeChart);
                await _context.SaveChangesAsync();

                response.Data = 1;

                return response;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occured: {ex.Message}";
                return response;
            }
        }

        public async Task<ServiceResponse<List<SizeChartResponseDto>>> GetAll()
        {
            var response = new ServiceResponse<List<SizeChartResponseDto>>();

            try
            {
                response.Data = await _context.SizeCharts
                    .Select(x => _mapper.Map<SizeChartResponseDto>(x))
                    .ToListAsync();

                return response;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occured: {ex.Message}";
                return response;
            }
        }

        public async Task<ServiceResponse<SizeChartResponseDto>> GetById(int Id)
        {
            var response = new ServiceResponse<SizeChartResponseDto>();

            try
            {
                response.Data = await _context.SizeCharts
                    .Where(x => x.Id == Id)
                    .Select(x => _mapper.Map<SizeChartResponseDto>(x))
                    .FirstOrDefaultAsync();

                return response;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occured: {ex.Message}";
                return response;
            }
        }

        public async Task<ServiceResponse<int>> Update(PutSizeChartRequestDto SizeChartData)
        {
            var response = new ServiceResponse<int>();

            try
            {
                var sizeChart = _mapper.Map<SizeChart>(SizeChartData);

                _context.Entry(sizeChart).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                response.Data = 1;

                return response;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occured: {ex.Message}";
                return response;
            }
        }

        public async Task<ServiceResponse<int>> Delete(int Id)
        {
            var response = new ServiceResponse<int>();

            try
            {
                var sizeChart = await _context.SizeCharts.Where(x => x.Id == Id).FirstOrDefaultAsync();

                if(sizeChart is null){
                    response.Success = false;
                    response.Message = "Record not found";
                    return response;
                }

                _context.SizeCharts.Remove(sizeChart!);
                await _context.SaveChangesAsync();

                response.Data = 1;
                return response;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occured: {ex.Message}";
                return response;
            }
        }
    }
}