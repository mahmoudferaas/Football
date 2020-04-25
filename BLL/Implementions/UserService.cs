using BLL.Abstractions;
using BLL.Common;
using BLL.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implementions
{
    public class UserService : IUserService
    {
        private UserManager<IdentityUser> _userManager;
        private readonly ApplicationSettings _appSettings;

        public UserService(UserManager<IdentityUser> userManager, IOptions<ApplicationSettings> appSettings )
        {
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        public async Task<object> Login(LoginInputDto model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {

                //Get role assigned to the user
                var role = await _userManager.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString()),
                        new Claim("UserName", user.UserName),
                        new Claim("Email", user.Email),
                        new Claim(_options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                //var refreshToken = _tokenService.GenerateRefreshToken();

                return new LoginOutputDto { Token = token , RefreshToken = "", Status = true };
            }
            else
                return new LoginOutputDto { 
                    Message = "Username or password is incorrect." ,
                    Status = false,
                    RefreshToken = string.Empty,
                    Token = string.Empty
                };
        }

        public async Task<object> PostUser(UserDto model)
        {
            var applicationUser = new IdentityUser()
            {
                UserName = model.UserName,
                Email = model.Email
            };

            try
            {
                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<object> GetUserProfile(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var role = await _userManager.GetRolesAsync(user);
            return new
            {
                user.Email,
                user.UserName,
                role
            };
        }
    }
}
