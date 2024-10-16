using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMW.Dtos.RequestDtos.SizeChartDto;
using SMW.Services.SizeChartService;

namespace SMW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SizeChartController : ControllerBase
    {
        private readonly ISizeChartService _sizeChartService;

        public SizeChartController(ISizeChartService sizeChartService)
        {
            _sizeChartService = sizeChartService;
        }

        
        [HttpPost("Add")]
        public async Task<IActionResult> Add(SizeChartRequestDto sizeChartData)
        {
            if(ModelState.IsValid){
                var response = await _sizeChartService.Add(sizeChartData);

                if(!response.Success)
                    return BadRequest(response);

                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            
            var response = await _sizeChartService.GetAll();

            if(!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            if(Id < 0)
                return NotFound();
            
            var response = await _sizeChartService.GetById(Id);

            if(!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> Update(PutSizeChartRequestDto sizeChartData, int Id)
        {
            if(ModelState.IsValid){
                if(Id != sizeChartData.Id)
                    return NotFound();

                var response = await _sizeChartService.Update(sizeChartData);

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
                
            var response = await _sizeChartService.Delete(Id);

            if(!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}