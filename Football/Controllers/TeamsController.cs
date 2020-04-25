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
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        { 
            _teamService = teamService;
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost("Create")]
        public async Task<Object> Create(TeamDto model)
        {
            try
            {
                var result = await _teamService.CreateAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [Authorize(Roles = "Administrator,Visitor")]
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<TeamDto>>> GetAll()
        {
            return await _teamService.GetAllAsync();
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<TeamDto>> GetById(int id)
        {
            return await _teamService.GetByIdAsync(id);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("Update/{id}")]
        public async Task<OutPutDto> Update(TeamDto TeamDto)
        {
            return await _teamService.UpdateAsync(TeamDto);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("Delete/{id}")]
        public async Task<OutPutDto> Delete(int id)
        {
            return await _teamService.DeleteAsync(id);
        }


    }
}
