using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMW.Dtos.RequestDtos.FabricSubCategoryDto;
using SMW.Services.FabricSubCategoryService;

namespace SMW.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Authorize]
    public class FabricSubCategoryController : ControllerBase
    {
        private readonly IFabricSubCategoryService _fabricSubCategoryService;
        public FabricSubCategoryController(IFabricSubCategoryService fabricSubCategoryService)
        {
            _fabricSubCategoryService = fabricSubCategoryService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(FabricSubCategoryRequestDto fabricSubCategoryData)
        {
            if(ModelState.IsValid)
            {
                var response =  await _fabricSubCategoryService.Add(fabricSubCategoryData);

                if (!response.Success)
                    return BadRequest(response);
                
                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            
            var response = await _fabricSubCategoryService.GetAll();

            if(!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            if(Id < 0)
                return NotFound();
            
            var response = await _fabricSubCategoryService.GetById(Id);

            if(!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> Update(PutFabricSubCategoryRequestDto fabricSubCategoryData, int Id)
        {
            if(ModelState.IsValid){
                if(Id != fabricSubCategoryData.Id)
                    return NotFound();

                var response = await _fabricSubCategoryService.Update(fabricSubCategoryData);

                if(!response.Success)
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
                
            var response = await _fabricSubCategoryService.Delete(Id);

            if(!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}