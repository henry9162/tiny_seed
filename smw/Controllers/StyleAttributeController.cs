using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SMW.Dtos.RequestDtos.StyleAttributeDto;
using SMW.Services.StyleAttributeService;

namespace SMW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StyleAttributeController : ControllerBase
    {
        private readonly IStyleAttributeService _styleAttributeService;
        public StyleAttributeController(IStyleAttributeService styleAttributeService)
        {
            _styleAttributeService = styleAttributeService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromForm] StyleAttributeRequestDto styleAttributeData)
        {
            if (ModelState.IsValid){
                var response = await _styleAttributeService.Add(styleAttributeData);

                if(!response.Success)
                    return BadRequest(response);

                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _styleAttributeService.GetAll();

            if(!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            if (Id < 1)
                return NotFound();
            
            var response = await _styleAttributeService.GetById(Id);

            if(!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("Update/{AttributeId}")]
        public async Task<IActionResult> Update([FromForm] PutStyleAttributeRequestDto styleAttributeData, int AttributeId)
        {
            if(ModelState.IsValid)
            {
                if (styleAttributeData.Id != AttributeId)
                    return NotFound();

                var response = await _styleAttributeService.Update(styleAttributeData);

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

            var response = await _styleAttributeService.Delete(Id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

    }
}