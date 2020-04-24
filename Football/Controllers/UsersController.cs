using System;
using System.Linq;
using System.Threading.Tasks;
using BLL.Abstractions;
using BLL.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Football.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<Object> PostUser(UserDto model)
        {
            try
            {
                var result = await _userService.PostUser(model);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginInputDto model)
        {
            var result = await _userService.Login(model);
            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        [Route("GetProfile")]
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            return (await _userService.GetUserProfile(userId));
        }
    }
}
