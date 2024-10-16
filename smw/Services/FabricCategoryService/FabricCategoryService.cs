using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMW.Data;
using SMW.Dtos.RequestDtos.FabricCategoryDto;
using SMW.Dtos.ResponseDtos.FabricCategoryDto;
using SMW.Models;

namespace SMW.Services.FabricCategoryService
{
    public class FabricCategoryService : IFabricCategoryService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public FabricCategoryService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<int>> Add(FabricCategoryRequestDto FabricCategoryData)
        {
            var response = new ServiceResponse<int>();

            try
            {
                var fabricCategory = _mapper.Map<FabricCategory>(FabricCategoryData);

                if (await Exists(fabricCategory.Name!)){
                    response.Success = false;
                    response.Message = "Record already exists";
                    return response;
                }
                
                _context.FabricCategories.Add(fabricCategory);
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

        public async Task<ServiceResponse<List<FabricCategoryResponseDto>>> GetAll()
        {
            var response = new ServiceResponse<List<FabricCategoryResponseDto>>();

            try
            {
                response.Data = await _context.FabricCategories
                    .Include(x => x.FabricSubCategories)
                    .Select(x => _mapper.Map<FabricCategoryResponseDto>(x))
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

        public async Task<ServiceResponse<FabricCategoryResponseDto>> GetById(int Id)
        {
            var response = new ServiceResponse<FabricCategoryResponseDto>();

            try
            {
                response.Data = await _context.FabricCategories
                    .Where(x => x.Id == Id)
                    .Include(x => x.FabricSubCategories)
                    .Select(x => _mapper.Map<FabricCategoryResponseDto>(x))
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

        public async Task<ServiceResponse<int>> Update(PutFabricCategoryRequestDto FabricData)
        {
            var response = new ServiceResponse<int>();

            try
            {
                var fabricCategory = _mapper.Map<FabricCategory>(FabricData);

                _context.Entry(fabricCategory).State = EntityState.Modified;

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
                var fabricCategory = await _context.FabricCategories.Where(x => x.Id == Id).FirstOrDefaultAsync();

                if(fabricCategory is null){
                    response.Success = false;
                    response.Message = "Record not found";
                    return response;
                }

                _context.FabricCategories.Remove(fabricCategory!);
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

        public async Task<bool> Exists(string Name)
        {
            if (await _context.FabricCategories.AnyAsync(x => x.Name == Name))
                return true;
            else
                return false;
        }
    }
}