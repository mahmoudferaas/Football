using AutoMapper;
using BLL.Abstractions;
using BLL.Dtos;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Implementions
{
    public class PlayerService : IPlayerService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Player> _repo;

        public PlayerService(IMapper mapper , IRepository<Player> repo )
        {
            _mapper = mapper;
            _repo = repo;

        }
        public async Task<OutPutDto> CreateAsync(PlayerDto PlayerDto)
        {
            var entity = _mapper.Map<Player>(PlayerDto);
            try
            {
                await _repo.Add(entity);
                return new OutPutDto
                {
                    Id = entity.Id,
                    IsSuccessed = true
                };
            }
            catch (Exception ex)
            {
                return new OutPutDto
                {
                    IsSuccessed = false
                };
            }
        }

        public async Task<OutPutDto> DeleteAsync(int id)
        {
            try
            {
                var entity = await _repo.GetById(id);
                await _repo.Remove(entity);
                return new OutPutDto
                {
                    IsSuccessed = true
                };
            }
            catch (Exception)
            {
                return new OutPutDto
                {
                    IsSuccessed = false
                };
            }
        }

        public async Task<List<PlayerDto>> GetAllAsync()
        {
            var Players = await _repo.GetAll();
            return _mapper.Map<List<PlayerDto>>(Players);
        }

        public IEnumerable<Player> GetAllByTeamId(int teamId)
        {
            return _repo.GetWhere(a => a.Team.Id == teamId);   
        }

        public async Task<PlayerDto> GetByIdAsync(int id)
        {
            try
            {
                Player Player = await _repo.GetById(id);

                return _mapper.Map<PlayerDto>(Player);
            }
            catch (Exception ex)
            {
                return new PlayerDto();
            }
        }

        public async Task<OutPutDto> UpdateAsync(PlayerDto Player)
        {
            var entity = _mapper.Map<Player>(Player);
            try
            {
                await _repo.Update(entity);
                return new OutPutDto
                {
                    Id = entity.Id,
                    IsSuccessed = true
                };
            }
            catch (Exception)
            {
                return new OutPutDto
                {
                    IsSuccessed = false
                };
            }

        }


    }
}
