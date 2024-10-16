using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMW.Data;
using SMW.Dtos.RequestDtos.StyleCategory;
using SMW.Dtos.ResponseDtos.StyleCategoryDto;
using SMW.Models;
using SMW.Services.AuthService;

namespace SMW.Services.StyleCategoryService
{
    public class StyleCategoryService : IStyleCategoryService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public StyleCategoryService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<int>> Add(StyleCategoryRequestDto category)
        {
            var response = new ServiceResponse<int>(); 

            try
            {
                if(await StyleCategoryExist(category!.Name!)){
                    response.Success = false;
                    response.Message = "Category already exist";
                    return response;
                }
                    
                var categoryModel = _mapper.Map<StyleCategory>(category);

                _context.StyleCategories.Add(categoryModel);
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
                var category = await _context.StyleCategories.Where(x => x.Id == id).FirstOrDefaultAsync();

                if(category is null || string.IsNullOrEmpty(category.Id.ToString()))
                {
                    response.Success = false;
                    response.Message = "This category does not exist";
                    return response;
                }

                _context.StyleCategories.Remove(category);
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

        public async Task<ServiceResponse<List<StyleCategoryResponseDto>>> GetAll()
        {
            var response = new ServiceResponse<List<StyleCategoryResponseDto>>();

            try
            {
                response.Data = await _context.StyleCategories
                    .Select(x => _mapper.Map<StyleCategoryResponseDto>(x))
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

        public async Task<ServiceResponse<StyleCategoryResponseDto>> GetById(int id)
        {
            var response = new ServiceResponse<StyleCategoryResponseDto>();

            try
            {
                response.Data = await _context.StyleCategories
                    .Where(x => x.Id == id)
                    .Select(x => _mapper.Map<StyleCategoryResponseDto>(x))
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

        public async Task<ServiceResponse<int>> Update(PutStyleCategoryRequestDto category)
        {
            var response = new ServiceResponse<int>();

            try
            {
                var styleCategory = _mapper.Map<StyleCategory>(category);

                _context.Entry(styleCategory).State = EntityState.Modified;
                
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

        public async Task<bool> StyleCategoryExist(string Name)
        {
            if (await _context.StyleCategories.AnyAsync(x => x.Name!.ToLower() == Name.ToLower()))
                return true;
            else
                return false;
        }
    }
}