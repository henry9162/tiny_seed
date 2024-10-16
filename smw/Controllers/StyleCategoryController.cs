using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMW.Dtos.RequestDtos.StyleCategory;
using SMW.Services.StyleCategoryService;

namespace SMW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StyleCategoryController : ControllerBase
    {
        private readonly IStyleCategoryService _styleCategoryService;
        public StyleCategoryController(IStyleCategoryService styleCategoryService)
        {
            _styleCategoryService = styleCategoryService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(StyleCategoryRequestDto request)
        {
            if(ModelState.IsValid){
                var response = await _styleCategoryService.Add(request);

                if(!response.Success)
                    return BadRequest(response);

                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(PutStyleCategoryRequestDto request, int id)
        {
            if(ModelState.IsValid){
                if (request.Id != id){
                    return NotFound();
                }

                var response = await _styleCategoryService.Update(request);

                if(!response.Success){
                    return BadRequest(response);
                }

                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _styleCategoryService.GetAll();

            if (!response.Success) {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _styleCategoryService.GetById(id);

            if(!response.Success){
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _styleCategoryService.Delete(id);

            if (!response.Success) {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}