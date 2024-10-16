using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SMW.Dtos.RequestDtos.StyleDto;
using SMW.Dtos.ResponseDtos.StyleDto;
using SMW.Services.StyleCategoryService;
using SMW.Services.StyleService;

namespace SMW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StyleController : ControllerBase
    {
        private readonly IStyleService _styleService;

        public StyleController(IStyleService styleService)
        {
            _styleService = styleService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromForm] StyleRequestDto StyleData)
        {
            if (ModelState.IsValid)
            {
                var response = await _styleService.Add(StyleData);

                 if (!response.Success)
                     return BadRequest(response);

                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _styleService.GetAll();

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            if (Id < 1)
                return NotFound();

            var response = await _styleService.GetById(Id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }


        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> Update(int Id,[FromForm] PutStyleRequestDto StyleData)
        {
            if (ModelState.IsValid)
            {
                if (Id != StyleData.Id)
                    return NotFound();
                    
                var response = await _styleService.Update(StyleData);

                if (!response.Success)
                    return BadRequest(response);

                return Ok(response);
            }

            return BadRequest(ModelState);
        }


        [HttpGet("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id < 1)
                return NotFound();

            var response = await _styleService.Delete(Id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

    }
}