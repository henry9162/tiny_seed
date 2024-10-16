using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SMW.Dtos.RequestDtos;
using SMW.Dtos.RequestDtos.AddressDto;
using SMW.Dtos.RequestDtos.FabricCategoryDto;
using SMW.Dtos.RequestDtos.FabricDto;
using SMW.Dtos.RequestDtos.FabricSubCategoryDto;
using SMW.Dtos.RequestDtos.ResponseDtos;
using SMW.Dtos.RequestDtos.StyleCategory;
using SMW.Dtos.RequestDtos.StyleDto;
using SMW.Dtos.RequestDtos.StyleSubCategoryDto;
using SMW.Dtos.ResponseDtos.AddressDto;
using SMW.Dtos.ResponseDtos.FabricCategoryDto;
using SMW.Dtos.ResponseDtos.FabricDto;
using SMW.Dtos.ResponseDtos.FabricSubCategoryDto;
using SMW.Dtos.ResponseDtos.StyleAttributeDto;
using SMW.Dtos.ResponseDtos.StyleCategoryDto;
using SMW.Dtos.ResponseDtos.StyleDto;
using SMW.Dtos.ResponseDtos.StyleSubCategoryDto;
using SMW.Dtos.ResponseDtos.UserManagement;
using SMW.Models;


namespace dotnet_rpg
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddressRequestDto, Address>();
            CreateMap<Address, AddressResponseDto>()
                .ForMember(d => d.State, o => o.MapFrom(x => x.State!.Name))
                .ForMember(d => d.LocalGovernment, o => o.MapFrom(x => x.LocalGovernment!.Name));
            CreateMap<State, StateResponseDto>();
            CreateMap<LocalGovernment, LocalGovernmentResponseDto>();
            CreateMap<RegisterRequestDto, ApplicationUser>();
            CreateMap<ApplicationUser, RegisterResponseDto>();
            CreateMap<PutAddressRequestDto, Address>();
            CreateMap<StyleCategory, StyleCategoryResponseDto>();
            CreateMap<StyleCategoryRequestDto, StyleCategory>();
            CreateMap<StyleSubCategoryRequestDto, StyleSubCategory>();
            CreateMap<StyleSubCategory, StyleSubCategoryResponseDto>();
            CreateMap<PutStyleSubCategoryRequestDto, StyleSubCategory>();
            CreateMap<PutStyleCategoryRequestDto, StyleCategory>();
            CreateMap<StyleAttribute, StyleAttributeResponseDto>();
            CreateMap<StyleRequestDto, Style>();
            CreateMap<Style, StyleResponseDto>();
            CreateMap<PutStyleRequestDto, Style>();
            CreateMap<FabricCategoryRequestDto, FabricCategory>();
            CreateMap<FabricCategory, FabricCategoryResponseDto>();
            CreateMap<FabricSubCategoryRequestDto, FabricSubCategory>();
            CreateMap<FabricSubCategory, FabricSubCategoryResponseDto>();
            CreateMap<PutFabricSubCategoryRequestDto, FabricSubCategory>();
            CreateMap<PutFabricCategoryRequestDto, FabricCategory>();
            CreateMap<Fabric, FabricResponseDto>();
            CreateMap<FabricRequestDto, Fabric>();
            CreateMap<PutFabricRequestDto, Fabric>();
        }
    }
}