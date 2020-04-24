using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Common
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddDAL(this IServiceCollection services , IConfiguration Configuration)
		{
			services.AddDbContext<FootballDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<FootballDbContext>();

			services.Configure<IdentityOptions>(options =>
			{
				options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";

				options.Password.RequireDigit = false;

				options.Password.RequireNonAlphanumeric = false;

				options.Password.RequireLowercase = false;

				options.Password.RequireUppercase = false;

				options.Password.RequiredLength = 4;
			});

			return services;
		}
	}
}
