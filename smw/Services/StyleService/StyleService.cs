using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Identity.Client;
using Org.BouncyCastle.Asn1.Icao;
using Org.BouncyCastle.Tls;
using SMW.Data;
using SMW.Dtos.RequestDtos.StyleDto;
using SMW.Dtos.ResponseDtos.StyleDto;
using SMW.Models;
using SMW.Models.shared;
using SMW.Services.StorageService;
using SMW.Utilities;
using SMW.Utilities.ModelAbstractions;

namespace SMW.Services.StyleService
{
    public class StyleService : IStyleService
    {
        private readonly DatabaseContext _context;
        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;
        private readonly IModelAbstractions<StyleAttribute> _modelAbstractions;

        public StyleService(DatabaseContext context, IStorageService storageService, IMapper mapper, IModelAbstractions<StyleAttribute> modelAbstractions)
        {
            _context = context;
            _storageService = storageService;
            _mapper = mapper;
            _modelAbstractions = modelAbstractions;
        }

        public async Task<ServiceResponse<int>> Add(StyleRequestDto StyleData)
        {
            var response = new ServiceResponse<int>();

            try
            {
                var imageUploads = await _storageService.UploadMultipleFiles<StyleImage>(StyleData.ImageFiles!, "Styles", null!);

                var style = _mapper.Map<Style>(StyleData);
                
                var styleAttributes = await _context.StyleAttributes
                    .Where(x => StyleData.AttributeIds!.Contains(x.Id))
                    .ToListAsync();

                style.StyleAttributes = styleAttributes;
                style.Amount = _modelAbstractions.GetListAmount(styleAttributes);
                style.StyleImages = imageUploads;

                _context.Styles.Add(style);
                await _context.SaveChangesAsync();

                response.Data = 1;
                return response;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = $"External exception: {ex.Message}";

                if (ex.InnerException is not null && !string.IsNullOrEmpty(ex.InnerException.Message)){
                    response.Message = string.Concat(response.Message, $"InnerException: {ex.InnerException.Message}");
                }
                
                return response;
            }
        }

        public async Task<ServiceResponse<List<StyleResponseDto>>> GetAll()
        {
            var response = new ServiceResponse<List<StyleResponseDto>>();

            try
            {
                response.Data = await _context.Styles
                    .Include(x => x.StyleSubCategory)
                    .Include(x => x.StyleAttributes)
                    .Include(x => x.StyleImages)
                    .Select(x => _mapper.Map<StyleResponseDto>(x))
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

        public async Task<ServiceResponse<StyleResponseDto>> GetById(int Id)
        {
            var response = new ServiceResponse<StyleResponseDto>();

            try
            {
                response.Data = await _context.Styles
                    .Where(x => x.Id == Id)
                    .Include(x => x.StyleSubCategory)
                    .Include(x => x.StyleAttributes)
                    .Include(x => x.StyleImages)
                    .Select(x => _mapper.Map<StyleResponseDto>(x))
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

        public async Task<ServiceResponse<int>> Update(PutStyleRequestDto StyleData)
        {
            var response = new ServiceResponse<int>();

            try
            {
                var dbPaths = _storageService.GetDbFilePaths<StyleImage>(StyleData.StyleImages!);
                
                var style = _mapper.Map<Style>(StyleData);

                style.StyleImages = await _storageService.UploadMultipleFiles<StyleImage>(StyleData.ImageFiles!, "Styles", dbPaths);
                style.StyleAttributes = _modelAbstractions.GetUpdatedItems(style.StyleAttributes!.ToList(), StyleData.AttributeIds!);
                style.Amount = _modelAbstractions.GetListAmount(style.StyleAttributes);
                
                _context.Entry(style).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                response.Data = 1;

                return response;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = $"External exception: {ex.Message}";

                if (ex.InnerException is not null && !string.IsNullOrEmpty(ex.InnerException.Message)){
                    response.Message = string.Concat(response.Message, $"InnerException: {ex.InnerException.Message}");
                }
                
                return response;
            }
        }

        public async Task<ServiceResponse<int>> Delete(int Id)
        {
            var response = new ServiceResponse<int>();

            try
            {
                var style = await _context.Styles.Where(x => x.Id == Id).FirstOrDefaultAsync();

                if(style is null){
                    response.Success = false;
                    response.Message = "Record not found";
                    return response;
                }

                var dbPaths = _storageService.GetDbFilePaths<StyleImage>(style.StyleImages!);

                _storageService.DeleteImageFromFileDirectory(dbPaths);

                _context.Styles.Remove(style!);
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

        // private double GetStyleAmount(List<StyleAttribute> styleAttributes)
        // {
        //     var styleAmount = 0.0;

        //     foreach (var attribute in styleAttributes){
        //         styleAmount += attribute.Price;
        //     }

        //     return styleAmount;
        // }

        // private List<StyleAttribute> GetUpdatedStyleAttributes(List<StyleAttribute> StyleAttributes, List<int> Ids)
        // {
        //     // Remove the styleAttribute which are not in the list of new sttributes
        //     foreach (var styleAtribute in StyleAttributes.ToList()){
        //         if (!Ids!.Contains(styleAtribute.Id))
        //             StyleAttributes.Remove(styleAtribute);
        //     }
            
        //     // Add the roles which are not in the list of user's roles
        //     foreach (var Id in Ids!)
        //     {
        //         if (!StyleAttributes.Any(x => x.Id == Id))
        //         {
        //             var newAttribute = new StyleAttribute { Id = Id };
        //             _context.StyleAttributes.Attach(newAttribute);
        //             StyleAttributes.Add(newAttribute);
        //         }
        //     }

        //     return StyleAttributes;
        // }
    }
}