using BLL.Dtos;
using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Abstractions
{
    public interface IPlayerService
    {
        Task<PlayerDto> GetByIdAsync(int id);
        IEnumerable<Player> GetAllByTeamId(int teamId);
        Task<List<PlayerDto>> GetAllAsync();
        Task<OutPutDto> CreateAsync(PlayerDto Player);
        Task<OutPutDto> UpdateAsync(PlayerDto Player);
        Task<OutPutDto> DeleteAsync(int id);

    }
}
