using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SMW.Data;
using SMW.Dtos.RequestDtos.StyleAttributeDto;
using SMW.Dtos.ResponseDtos.StyleAttributeDto;
using SMW.Models;
using SMW.Models.shared;
using SMW.Services.StorageService;

namespace SMW.Services.StyleAttributeService
{
    public class StyleAttributService : IStyleAttributeService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IStorageService _storageService;

        public StyleAttributService(DatabaseContext context, IMapper mapper, IStorageService storageService)
        {
            _context = context;
            _mapper = mapper;
            _storageService = storageService;
        }

        public async Task<ServiceResponse<int>> Add(StyleAttributeRequestDto styleAttributeData)
        {
            var response = new ServiceResponse<int>();

            try 
            {
                if (await StyleAttributeExist(styleAttributeData.Name!)){
                    response.Success = false;
                    response.Message = "Attribute already exist";
                    return response;
                }

                var styleAttribute = _mapper.Map<StyleAttribute>(styleAttributeData);
               
                if(styleAttributeData.Image is not null && styleAttributeData.Image.Length > 0){
                    var imageUpload = await _storageService.UploadFormFile(styleAttributeData.Image, "StyleAttributes");

                    styleAttribute.ImagePath = imageUpload.FilePath;
                    styleAttribute.ImageName = imageUpload.FileName;
                }

                _context.StyleAttributes.Add(styleAttribute);
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

        public async Task<ServiceResponse<List<StyleAttributeResponseDto>>> GetAll()
        {
            var response = new ServiceResponse<List<StyleAttributeResponseDto>>();

            try
            {
                response.Data = await _context.StyleAttributes
                    .Select(x => _mapper.Map<StyleAttributeResponseDto>(x))
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

        public async Task<ServiceResponse<StyleAttributeResponseDto>> GetById(int Id)
        {
            var response = new ServiceResponse<StyleAttributeResponseDto>();

            try
            {
                response.Data = await _context.StyleAttributes
                    .Where(x => x.Id == Id)
                    .Select(x => _mapper.Map<StyleAttributeResponseDto>(x))
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

        public async Task<ServiceResponse<int>> Update(PutStyleAttributeRequestDto styleAttributeData)
        {
            var response = new ServiceResponse<int>();

            try
            {
                var styleAttribute = await _context.StyleAttributes.Where(x => x.Id == styleAttributeData.Id).FirstOrDefaultAsync();

                if (styleAttributeData.Image is not null && styleAttributeData.Image.Length > 0){
                    var imageUpload = await _storageService.UploadFormFile(styleAttributeData.Image!, "StyleAttributes", styleAttribute!.ImagePath!);

                    styleAttribute.ImagePath = imageUpload.FilePath;
                    styleAttribute.ImageName = imageUpload.FileName;
                }

                styleAttribute!.Name = styleAttributeData.Name;
                styleAttribute.Sex = styleAttributeData.Sex;
                styleAttribute.Price = styleAttributeData.Price;

                _context.Entry(styleAttribute).State = EntityState.Modified;
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
                var styleAttribute = await _context.StyleAttributes
                    .Where(x => x.Id == Id)
                    .FirstOrDefaultAsync();

                if(styleAttribute is null){
                    response.Success = false;
                    response.Message = "Record not found";
                    return response;
                }

                _storageService.DeleteImageFromFileDirectory(new List<string>{styleAttribute!.ImagePath!});

                _context.StyleAttributes.Remove(styleAttribute!);
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

        public async Task<bool> StyleAttributeExist(string Name)
        {
            if (await _context.StyleAttributes.AnyAsync(x => x.Name!.ToLower() == Name.ToLower()))
                return true;
            else
                return false;
        }
    }
}