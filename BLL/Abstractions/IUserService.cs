using BLL.Dtos;
using System;
using System.Threading.Tasks;

namespace BLL.Abstractions
{
    public interface IUserService
    {
        Task<Object> PostUser(UserDto model);
        Task<Object> Login(LoginInputDto model);
        Task<Object> GetUserProfile(string userId);

    }
}
