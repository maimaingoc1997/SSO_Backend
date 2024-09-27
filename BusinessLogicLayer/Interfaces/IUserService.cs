using BusinessLogicLayer.Services;

using DataAccessLayer.Models;
using DataAccessLayer.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IUserService
    {
         Task<(bool Success, string Message)> RegisterUserAsync(UserDTO userDto);
        string Login(LoginDTO loginDto, out string token);
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);

    }
}
