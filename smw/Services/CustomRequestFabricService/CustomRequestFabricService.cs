using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMW.Data;
using SMW.Dtos.RequestDtos.CustomFabricDto;
using SMW.Dtos.ResponseDtos.CustomFabricDto;
using SMW.Models;

namespace SMW.Services.CustomRequestFabricService
{
    public class CustomRequestFabricService : ICustomRequestFabricService
    {
        private readonly DatabaseContext _context;
        private IMapper _mapper;

        public CustomRequestFabricService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<int>> Add(List<CustomFabricRequestDto> CustomRequestFabricData)
        {
            var response = new ServiceResponse<int>();

            try
            {
                foreach (var CustomRequestFabric in CustomRequestFabricData)
                {
                    var customRequestFabric = _mapper.Map<CustomRequestFabric>(CustomRequestFabricData);
                    _context.CustomRequestFabrics.Add(customRequestFabric);
                }
                
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

        public async Task<ServiceResponse<List<CustomFabricResponseDto>>> GetAll()
        {
            var response = new ServiceResponse<List<CustomFabricResponseDto>>();

            try
            {
                response.Data = await _context.CustomRequestFabrics
                    .Select(x => _mapper.Map<CustomFabricResponseDto>(x))
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

        public async Task<ServiceResponse<CustomFabricResponseDto>> GetById(int Id)
        {
            var response = new ServiceResponse<CustomFabricResponseDto>();

            try
            {
                response.Data = await _context.CustomRequestFabrics
                    .Where(x => x.Id == Id)
                    .Select(x => _mapper.Map<CustomFabricResponseDto>(x))
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

        public async Task<ServiceResponse<int>> Update(PutCustomFabricRequestDto CustomRequestFabricData)
        {
            var response = new ServiceResponse<int>();

            try
            {
                var customRequestFabric = _mapper.Map<CustomRequestFabric>(CustomRequestFabricData);

                _context.Entry(customRequestFabric).State = EntityState.Modified;

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
                var customRequestFabric = await _context.CustomRequestFabrics.Where(x => x.Id == Id).FirstOrDefaultAsync();

                if(customRequestFabric is null){
                    response.Success = false;
                    response.Message = "Record not found";
                    return response;
                }

                _context.CustomRequestFabrics.Remove(customRequestFabric!);
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