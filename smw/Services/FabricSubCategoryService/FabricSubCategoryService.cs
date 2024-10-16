using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMW.Data;
using SMW.Dtos.RequestDtos.FabricSubCategoryDto;
using SMW.Dtos.ResponseDtos.FabricSubCategoryDto;
using SMW.Models;

namespace SMW.Services.FabricSubCategoryService
{
    public class FabricSubCategoryService : IFabricSubCategoryService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public FabricSubCategoryService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<ServiceResponse<int>> Add(FabricSubCategoryRequestDto FabricSubCategoryData)
        {
            var response = new ServiceResponse<int>();

            try
            {
                var fabricSubCategory = _mapper.Map<FabricSubCategory>(FabricSubCategoryData);

                if (await Exists(fabricSubCategory.Name!)){
                    response.Success = false;
                    response.Message = "Record already exists";
                    return response;
                }
                
                _context.FabricSubCategories.Add(fabricSubCategory);
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

        public async Task<ServiceResponse<List<FabricSubCategoryResponseDto>>> GetAll()
        {
            var response = new ServiceResponse<List<FabricSubCategoryResponseDto>>();

            try
            {
                response.Data = await _context.FabricSubCategories
                    .Select(x => _mapper.Map<FabricSubCategoryResponseDto>(x))
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

        public async Task<ServiceResponse<FabricSubCategoryResponseDto>> GetById(int Id)
        {
            var response = new ServiceResponse<FabricSubCategoryResponseDto>();

            try
            {
                response.Data = await _context.FabricSubCategories
                    .Where(x => x.Id == Id)
                    .Select(x => _mapper.Map<FabricSubCategoryResponseDto>(x))
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

        public async Task<ServiceResponse<int>> Update(PutFabricSubCategoryRequestDto FabricSubCategoryData)
        {
            var response = new ServiceResponse<int>();

            try
            {
                var fabricSubCategory = _mapper.Map<FabricSubCategory>(FabricSubCategoryData);

                _context.Entry(fabricSubCategory).State = EntityState.Modified;

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
                var fabricSubCategory = await _context.FabricSubCategories.Where(x => x.Id == Id).FirstOrDefaultAsync();

                if(fabricSubCategory is null){
                    response.Success = false;
                    response.Message = "Record not found";
                    return response;
                }

                _context.FabricSubCategories.Remove(fabricSubCategory!);
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
            if (await _context.FabricSubCategories.AnyAsync(x => x.Name == Name))
                return true;
            else
                return false;
        }
    }
}