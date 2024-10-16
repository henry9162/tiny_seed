using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SMW.Dtos.RequestDtos.AddressDto;
using SMW.Services.AddressService;

namespace SMW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService){
            this._addressService = addressService;
        }

        [HttpPost("addAddress")]
        public async Task<IActionResult> AddAddress(AddressRequestDto address)
        {
            if (ModelState.IsValid)
            {
                var response = await _addressService.AddAddress(address);

                if(!response.Success)
                    return BadRequest(response);

                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("getAllUserAddresses")]
        public async Task<IActionResult> GetAllUserAddresses()
        {
            var response = await _addressService.GetAllUserAddresses();
            
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("getAllStates")]
        public async Task<IActionResult> GetAllStates()
        {
            var response = await _addressService.GetAllStates();
            
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("getLocalGovernments/{stateId}")]
        public async Task<IActionResult> GetLocalGovernments([FromRoute] int stateId)
        {
            if(stateId > 0){
                var response = await _addressService.GetLocalGovernments(stateId);
            
                if (!response.Success)
                    return BadRequest(response);

                return Ok(response);
            }
            
            return BadRequest("Invalid state");
        }

        [HttpPut("UpdateUserAddress/{putAddressId}")]
        public async Task<IActionResult> UpdateUserAddress(PutAddressRequestDto address, int putAddressId)
        {
            if (ModelState.IsValid){
                if (address.Id != putAddressId)
                    return NotFound();

                var response = await _addressService.UpdateAddress(address, putAddressId);

                if (!response.Success)
                    return BadRequest(response);

                return Ok(response);
            }
 
            return BadRequest(ModelState);
        }

        [HttpDelete("DeleteAddress/{addressId}/{userId}")]
        public async Task<IActionResult> DeleteAddress(int addressId, string userId)
        {
            if (addressId < 1)
                return NotFound();

            var response = await _addressService.DeleteAddress(addressId, userId);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

    }

}