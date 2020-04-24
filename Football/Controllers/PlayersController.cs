using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Abstractions;
using BLL.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Football.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _PlayerService;

        public PlayersController(IPlayerService PlayerService)
        { 
            _PlayerService = PlayerService;
        }

        [HttpPost("Create")]
        public async Task<Object> Create(PlayerDto model)
        {
            try
            {
                var result = await _PlayerService.CreateAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpGet("GetAll")]
        //[Authorize(Roles = "Visitor")]
        public async Task<ActionResult<IEnumerable<PlayerDto>>> GetAll()
        {
            return await _PlayerService.GetAllAsync();
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<PlayerDto>> GetById(int id)
        {
            return await _PlayerService.GetByIdAsync(id);
        }

        [HttpPut("Update/{id}")]
        public async Task<OutPutDto> Update(PlayerDto PlayerDto)
        {
            return await _PlayerService.UpdateAsync(PlayerDto);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<OutPutDto> Delete(int id)
        {
            return await _PlayerService.DeleteAsync(id);
        }


    }
}
