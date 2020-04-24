using AutoMapper;
using BLL.Abstractions;
using BLL.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implementions
{
    public class RoleService : IRoleService
    {
        private RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IRepository<IdentityRole> _repo;

        public RoleService(RoleManager<IdentityRole> roleMgr, IMapper mapper, IRepository<IdentityRole> repo)
        {
            _roleManager = roleMgr;
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<OutPutDto> CreateRoleAsync(RolesDto role)
        {
            try
            {
                var roleEntity = new IdentityRole { Name = role.Name };
                await _roleManager.CreateAsync(roleEntity);
                return new OutPutDto
                {
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

        public async Task<OutPutDto> DeleteRoleAsync(string roleId)
        {
            try
            {
                IdentityRole role = await _roleManager.FindByIdAsync(roleId);

                IdentityResult result = await _roleManager.DeleteAsync(role);
                return new OutPutDto
                {
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

        public List<RolesDto> GetAllRoles()
        {
            var role = _repo.GetAll();
            return _mapper.Map<List<RolesDto>>(role);
        }

        public async Task<RolesDto> GetRoleByIdAsync(string id)
        {
            try
            {
                IdentityRole role = await _roleManager.FindByIdAsync(id);

                return _mapper.Map<RolesDto>(role);

            }
            catch (Exception ex)
            {
                return new RolesDto();
            }
        }

        public async Task<OutPutDto> UpdateRoleAsync(RolesDto role)
        {
            try
            {
                IdentityRole entity = await _roleManager.FindByIdAsync(role.Id);
                entity.Name = role.Name;
                await _roleManager.UpdateAsync(entity);
                return new OutPutDto
                {
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

    }
}
