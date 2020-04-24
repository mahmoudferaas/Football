using AutoMapper;
using BLL.Abstractions;
using BLL.Implementions;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BLL.Common
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddBLL(this IServiceCollection services)
		{

			services.AddScoped<IRepository<Team>, Repository<Team>>();
			services.AddScoped<IRepository<Player>,Repository<Player>>();
			services.AddScoped<IRepository<IdentityRole>, Repository<IdentityRole>>();

			services.AddScoped<ITeamService, TeamService>();
			services.AddScoped<IPlayerService, PlayerService>();

			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IRoleService, RoleService>();

			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			return services;
		}
	}
}
