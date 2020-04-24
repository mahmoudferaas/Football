using AutoMapper;
using BLL.Abstractions;
using BLL.Dtos;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Implementions
{
    public class TeamService : ITeamService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Team> _repo;

        public TeamService(IMapper mapper , IRepository<Team> repo )
        {
            _mapper = mapper;
            _repo = repo;

        }
        public async Task<OutPutDto> CreateAsync(TeamDto teamDto )
        {
            var entity = _mapper.Map<Team>(teamDto);
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

        public async Task<List<TeamDto>> GetAllAsync()
        {
            var teams = await _repo.GetAll();
            return _mapper.Map<List<TeamDto>>(teams);
        }

        public async Task<TeamDto> GetByIdAsync(int id)
        {
            try
            {
                Team team = await _repo.GetById(id);

                return _mapper.Map<TeamDto>(team);
            }
            catch (Exception ex)
            {
                return new TeamDto();
            }
        }

        public async Task<OutPutDto> UpdateAsync(TeamDto team)
        {
            var entity = _mapper.Map<Team>(team);
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
