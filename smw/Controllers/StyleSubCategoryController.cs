using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMW.Dtos.RequestDtos.StyleSubCategoryDto;
using SMW.Services.StyleSubCategoryService;

namespace SMW.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize]
    public class StyleSubCategoryController : ControllerBase
    {
        private readonly IStyleSubCategoryService _styleSubCategoryService;

        public StyleSubCategoryController(IStyleSubCategoryService styleSubCategoryService)
        {
            _styleSubCategoryService = styleSubCategoryService;   
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(StyleSubCategoryRequestDto styleSubCategoryData)
        {
            if(ModelState.IsValid)
            {
                var response = await _styleSubCategoryService.Add(styleSubCategoryData);
                if(!response.Success)
                    return BadRequest(response);

                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _styleSubCategoryService.GetAll();

            if (!response.Success) {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _styleSubCategoryService.GetById(id);

            if(!response.Success){
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(PutStyleSubCategoryRequestDto request, int id)
        {
            if(ModelState.IsValid){
                if (request.Id != id){
                    return NotFound();
                }

                var response = await _styleSubCategoryService.Update(request);

                if(!response.Success){
                    return BadRequest(response);
                }

                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _styleSubCategoryService.Delete(id);

            if (!response.Success) {
                return BadRequest(response);
            }

            return Ok(response);
        }

    }
}