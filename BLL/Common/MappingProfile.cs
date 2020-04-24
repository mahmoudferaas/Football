using AutoMapper;
using BLL.Dtos;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace BLL.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TeamDto, Team>().ReverseMap();
            CreateMap<PlayerDto, Player>().ReverseMap();
            CreateMap<RolesDto, IdentityRole>().ReverseMap();
        }
    }
}