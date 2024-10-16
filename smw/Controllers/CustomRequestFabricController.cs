using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMW.Dtos.RequestDtos.CustomFabricDto;
using SMW.Services.CustomRequestFabricService;

namespace SMW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CustomRequestFabricController : ControllerBase
    {
        private readonly ICustomRequestFabricService _customRequestFabricService;

        public CustomRequestFabricController(ICustomRequestFabricService customRequestFabricService)
        {
            _customRequestFabricService = customRequestFabricService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(List<CustomFabricRequestDto> customFabricData)
        {
            if(ModelState.IsValid){
                var response = await _customRequestFabricService.Add(customFabricData);

                if(!response.Success)
                    return BadRequest(response);

                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            
            var response = await _customRequestFabricService.GetAll();

            if(!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            if(Id < 0)
                return NotFound();
            
            var response = await _customRequestFabricService.GetById(Id);

            if(!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> Update(PutCustomFabricRequestDto customFabricData, int Id)
        {
            if(ModelState.IsValid){
                if(Id != customFabricData.Id)
                    return NotFound();

                var response = await _customRequestFabricService.Update(customFabricData);

                if(!response.Success)
                    return BadRequest(response);

                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            if(Id < 1)
                return NotFound();
                
            var response = await _customRequestFabricService.Delete(Id);

            if(!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}