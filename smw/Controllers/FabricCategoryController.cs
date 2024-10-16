using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SMW.Dtos.RequestDtos.FabricCategoryDto;
using SMW.Services.FabricCategoryService;

namespace SMW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FabricCategoryController : ControllerBase
    {
        private readonly IFabricCategoryService _fabricCategoryService;
        public FabricCategoryController(IFabricCategoryService fabricCategoryService)
        {
            _fabricCategoryService = fabricCategoryService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(FabricCategoryRequestDto fabricCategoryData)
        {
            if(ModelState.IsValid){
                var response = await _fabricCategoryService.Add(fabricCategoryData);

                if(!response.Success)
                    return BadRequest(response);

                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            
            var response = await _fabricCategoryService.GetAll();

            if(!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            if(Id < 0)
                return NotFound();
            
            var response = await _fabricCategoryService.GetById(Id);

            if(!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> Update(PutFabricCategoryRequestDto fabricCategoryData, int Id)
        {
            if(ModelState.IsValid){
                if(Id != fabricCategoryData.Id)
                    return NotFound();

                var response = await _fabricCategoryService.Update(fabricCategoryData);

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
                
            var response = await _fabricCategoryService.Delete(Id);

            if(!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}