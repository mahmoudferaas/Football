using BLL.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Abstractions
{
    public interface IRoleService
    {
        Task<RolesDto> GetRoleByIdAsync(string id);
        List<RolesDto> GetAllRoles();
        Task<OutPutDto> CreateRoleAsync(RolesDto role);
        Task<OutPutDto> UpdateRoleAsync(RolesDto role);
        Task<OutPutDto> DeleteRoleAsync(string roleId);

    }
}
