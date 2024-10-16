using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using SMW.Controllers;
using SMW.Dtos.RequestDtos.AddressDto;
using SMW.Dtos.ResponseDtos.AddressDto;
using SMW.Dtos.ResponseDtos.UserManagement;
using SMW.Models;
using SMW.Services.AddressService;

namespace SMWTests
{
    public class AddressControllerTests
    {
        private readonly Mock<IAddressService> _addressService;
        private Fixture _fixture;
        private readonly AddressController _addressController;

        public AddressControllerTests()
        {
            _addressService = new Mock<IAddressService>();
            _fixture = new Fixture();
            _addressController = new AddressController(_addressService.Object);
        }

        [Fact]
        public async void AddAddress_ReturnOkResultWithAddressResponseDto()
        {
            //Arrange
            var address = _fixture.Create<AddressRequestDto>();

            var response = _fixture.Create<ServiceResponse<List<AddressResponseDto>>>();

            _addressService.Setup(x => x.AddAddress(address)).ReturnsAsync(response);

            //Act
            var controllerResponse = await _addressController.AddAddress(address);
            var result = controllerResponse as OkObjectResult;
            var serializedContentResult = JsonConvert.SerializeObject(result!.Value);
            var contentResult = JsonConvert.DeserializeObject<ServiceResponse<List<AddressResponseDto>>>(serializedContentResult);
            
            //Assert
            Assert.Equal(200, result!.StatusCode);
            Assert.IsType<ServiceResponse<List<AddressResponseDto>>>(result.Value);
        }

        [Fact]
        public async Task GetAllUserAddress_ReturnOkResultWitUserAddresses()
        {
            //Arrange
            var response = _fixture.Create<ServiceResponse<List<AddressResponseDto>>>();

            _addressService.Setup(x => x.GetAllUserAddresses()).ReturnsAsync(response);

            //Act
            var controllerResponse = await _addressController.GetAllUserAddresses();
            var result = controllerResponse as OkObjectResult;

            //Assert
            Assert.Equal(200, result!.StatusCode);
            Assert.IsType<ServiceResponse<List<AddressResponseDto>>>(result.Value);
        }

        [Fact]
        public async Task GetAllStates_ReturnOkResultWithAllStates()
        {
            //Arrange
            var response = _fixture.Create<ServiceResponse<List<StateResponseDto>>>();
            _addressService.Setup(x => x.GetAllStates()).ReturnsAsync(response);

            //Act
            var controllerResponse = await _addressController.GetAllStates();
            var result = controllerResponse as OkObjectResult;

            //Assert
            Assert.Equal(200, result!.StatusCode);
            Assert.IsType<ServiceResponse<List<StateResponseDto>>>(result.Value);
        }

        [Fact]
        public async Task GetLocalGovernments_ReturnOkResultWithAllLocalgovernment()
        {
            //Arrange
            var response = _fixture.Create<ServiceResponse<List<LocalGovernmentResponseDto>>>();
            _addressService.Setup(x => x.GetLocalGovernments(response.Data![0].Id)).ReturnsAsync(response);

            //Act
            var controllerResponse = await _addressController.GetLocalGovernments(response.Data![0].Id);
            var result = controllerResponse as OkObjectResult;

            //Assert
            Assert.Equal(200, result!.StatusCode);
            Assert.IsType<ServiceResponse<List<LocalGovernmentResponseDto>>>(result.Value);
        }

        [Fact]
        public async Task UpdateUserAddress_ReturnOkResult()
        {
            //Arrange
            var address = _fixture.Create<PutAddressRequestDto>();
            var response = _fixture.Create<ServiceResponse<int>>();

            _addressService.Setup(x => x.UpdateAddress(address, address.Id)).ReturnsAsync(response);

            //Act
            var controllerResponse = await _addressController.UpdateUserAddress(address, address.Id);
            var result = controllerResponse as OkObjectResult;

            //Assert
            Assert.Equal(200, result!.StatusCode);
            Assert.IsType<ServiceResponse<int>>(result.Value);
        }

        [Fact]
        public async Task UpdateUserAddress_ReturnBadRequest()
        {
            //Arrange
            var address = _fixture.Create<PutAddressRequestDto>();
            var response = new ServiceResponse<int>() { Success = false };

            _addressService.Setup(x => x.UpdateAddress(address, address.Id)).ReturnsAsync(response);

            //Act
            var controllerResponse = await _addressController.UpdateUserAddress(address, address.Id);
            
            //Assert
            Assert.IsType<BadRequestObjectResult>(controllerResponse);
        }

        [Fact]
        public async Task DeleteAddress_ReturnOkResult()
        {
            //Arrange
            var response = _fixture.Create<ServiceResponse<int>>();
            var addressId = _fixture.Create<int>();
            var userId = _fixture.Create<string>();

            _addressService.Setup(x => x.DeleteAddress(addressId, userId)).ReturnsAsync(response);

            //Act
            var controllerResponse = await _addressController.DeleteAddress(addressId, userId);
            var result = controllerResponse as OkObjectResult;

            //Assert
            Assert.Equal(200, result!.StatusCode);
            Assert.IsType<ServiceResponse<int>>(result.Value);
        }
    }
}