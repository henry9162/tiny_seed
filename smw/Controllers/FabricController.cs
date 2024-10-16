using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMW.Dtos.RequestDtos.FabricDto;
using SMW.Services.FabricService;

namespace SMW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FabricController : ControllerBase
    {
        private readonly IFabricService _fabricService;
        public FabricController(IFabricService fabricService)
        {
            _fabricService = fabricService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromForm] FabricRequestDto FabricData)
        {
            if (ModelState.IsValid){
                var response = await _fabricService.Add(FabricData);

                if (!response.Success)
                    return BadRequest(response);

                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _fabricService.GetAll();

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
        
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            if(Id < 1)
                return NotFound();

            var response = await _fabricService.GetById(Id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> Update([FromForm] PutFabricRequestDto FabricData, int Id)
        {
            if (ModelState.IsValid){
                if(Id != FabricData.Id)
                    return NotFound();

                var response = await _fabricService.Update(FabricData);

                if (!response.Success)
                    return BadRequest(response);

                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            if(Id < 1)
                return NotFound();

            var response = await _fabricService.Delete(Id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}