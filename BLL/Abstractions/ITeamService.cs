using BLL.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Abstractions
{
    public interface ITeamService
    {
        Task<TeamDto> GetByIdAsync(int id);
        Task<List<TeamDto>> GetAllAsync();
        Task<OutPutDto> CreateAsync(TeamDto team);
        Task<OutPutDto> UpdateAsync(TeamDto team);
        Task<OutPutDto> DeleteAsync(int id);

    }
}
