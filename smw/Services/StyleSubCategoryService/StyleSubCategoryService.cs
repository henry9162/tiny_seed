using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMW.Data;
using SMW.Dtos.RequestDtos.StyleSubCategoryDto;
using SMW.Dtos.ResponseDtos.StyleSubCategoryDto;
using SMW.Models;

namespace SMW.Services.StyleSubCategoryService
{
    public class StyleSubCategoryService : IStyleSubCategoryService
    {
         private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public StyleSubCategoryService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<int>> Add(StyleSubCategoryRequestDto subCategory)
        {
            var response = new ServiceResponse<int>(); 

            try
            {
                if(await StyleSubCategoryExist(subCategory!.Name!)){
                    response.Success = false;
                    response.Message = "SubCategory already exist";
                    return response;
                }
                    
                var subCategoryData = _mapper.Map<StyleSubCategory>(subCategory);

                _context.StyleSubCategories.Add(subCategoryData);
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

        public async Task<ServiceResponse<List<StyleSubCategoryResponseDto>>> GetAll()
        {
            var response = new ServiceResponse<List<StyleSubCategoryResponseDto>>();

            try
            {
                response.Data = await _context.StyleSubCategories
                    .Select(x => _mapper.Map<StyleSubCategoryResponseDto>(x))
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

        public async Task<ServiceResponse<StyleSubCategoryResponseDto>> GetById(int id)
        {
            var response = new ServiceResponse<StyleSubCategoryResponseDto>();

            try
            {
                response.Data = await _context.StyleSubCategories
                    .Where(x => x.Id == id)
                    .Select(x => _mapper.Map<StyleSubCategoryResponseDto>(x))
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

        public async Task<ServiceResponse<int>> Update(PutStyleSubCategoryRequestDto category)
        {
            var response = new ServiceResponse<int>();

            try
            {
                var styleSubCategory = _mapper.Map<StyleSubCategory>(category);

                _context.Entry(styleSubCategory).State = EntityState.Modified;
                
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

        public async Task<ServiceResponse<int>> Delete(int id)
        {
            var response = new ServiceResponse<int>();

            try
            {
                var subCategorycategory = await _context.StyleSubCategories.Where(x => x.Id == id).FirstOrDefaultAsync();

                if(subCategorycategory is null || string.IsNullOrEmpty(subCategorycategory.Id.ToString()))
                {
                    response.Success = false;
                    response.Message = "This sub-category does not exist";
                    return response;
                }

                _context.StyleSubCategories.Remove(subCategorycategory);
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

        public async Task<bool> StyleSubCategoryExist(string Name)
        {
            if (await _context.StyleCategories.AnyAsync(x => x.Name!.ToLower() == Name.ToLower()))
                return true;
            else
                return false;
        }
    }
}