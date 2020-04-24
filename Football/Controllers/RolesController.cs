using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Abstractions;
using BLL.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Football.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _rolesService;

        public RolesController(IRoleService rolesService)
        {
            _rolesService = rolesService;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<RolesDto>> Get()
        {
            return _rolesService.GetAllRoles();
        }

        [HttpGet("GetRoleById")]
        public Task<RolesDto> GetRoleById(string Id)
        {
            return _rolesService.GetRoleByIdAsync(Id);
        }


        // POST values
        [HttpPost("Create")]
        public Task<OutPutDto> Post([FromBody] RolesDto RolesDto)
        {
            return _rolesService.CreateRoleAsync(RolesDto);
        }

        // PUT values/5
        [HttpPut("Update")]
        public Task<OutPutDto> Put(RolesDto RolesDto)
        {
            return _rolesService.UpdateRoleAsync(RolesDto);
        }

        // DELETE values/5
        [HttpDelete("Delete")]
        public Task<OutPutDto> Delete(string id)
        {
            return _rolesService.DeleteRoleAsync(id);
        }
    }
}
