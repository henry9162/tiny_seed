using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SMW.Data;
using SMW.Dtos.RequestDtos.FabricDto;
using SMW.Dtos.ResponseDtos.FabricDto;
using SMW.Models;
using SMW.Services.StorageService;
using SMW.Utilities;
using SMW.Utilities.ModelAbstractions;

namespace SMW.Services.FabricService
{
    public class FabricService : IFabricService
    {
        private readonly DatabaseContext _context;
        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;
        private readonly  IModelAbstractions<FabricSubCategory> _modelAbstractions;

        public FabricService(IStorageService storageService, DatabaseContext context, IMapper mapper, IModelAbstractions<FabricSubCategory> modelAbstractions)
        {
            _storageService = storageService;
            _context = context;
            _mapper = mapper;
            _modelAbstractions = modelAbstractions;
        }

        public async Task<ServiceResponse<int>> Add(FabricRequestDto FabricData)
        {
            var response = new ServiceResponse<int>();

            try
            {
                var dbPaths = new string[]{};

                var imageUploads = await _storageService.UploadMultipleFiles<FabricImage>(FabricData.ImageFiles!, "Fabrics", null!);

                var fabric = _mapper.Map<Fabric>(FabricData);
                fabric.FabricImages = imageUploads;

                _context.Fabrics.Add(fabric);
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

        public async Task<ServiceResponse<List<FabricResponseDto>>> GetAll()
        {
            var response = new ServiceResponse<List<FabricResponseDto>>();

            try
            {
                response.Data = await _context.Fabrics
                    .Include(x => x.FabricSubCategory)
                    .Include(x => x.FabricImages)
                    .Select(x => _mapper.Map<FabricResponseDto>(x))
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

        public async Task<ServiceResponse<FabricResponseDto>> GetById(int Id)
        {
            
            var response = new ServiceResponse<FabricResponseDto>();

            try
            {
                response.Data = await _context.Fabrics
                    .Where(x => x.Id == Id)
                    .Include(x => x.FabricSubCategory)
                    .Include(x => x.FabricImages)
                    .Select(x => _mapper.Map<FabricResponseDto>(x))
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

        public async Task<ServiceResponse<int>> Update(PutFabricRequestDto FabricData)
        {
            var response = new ServiceResponse<int>();

            try
            {   
                var dbPaths = _storageService.GetDbFilePaths<FabricImage>(FabricData.FabricImages!);

                var fabricDb = await _context.Fabrics.Include(x => x.FabricSubCategory).Where(x => x.Id == FabricData.Id).FirstOrDefaultAsync();
                
                var fabric = _mapper.Map<Fabric>(FabricData);
                fabric.FabricImages = await _storageService.UploadMultipleFiles<FabricImage>(FabricData.ImageFiles!, "Styles", dbPaths);
                
                _context.Entry(fabric).State = EntityState.Modified;
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
                var fabric = await _context.Fabrics.Where(x => x.Id == Id).FirstOrDefaultAsync();

                if(fabric is null){
                    response.Success = false;
                    response.Message = "Record not found";
                    return response;
                }

                var dbPaths = _storageService.GetDbFilePaths<FabricImage>(fabric.FabricImages!);

                _storageService.DeleteImageFromFileDirectory(dbPaths);

                _context.Fabrics.Remove(fabric);
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