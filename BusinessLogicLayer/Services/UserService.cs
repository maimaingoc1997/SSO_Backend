using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Models.DTOs;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{

    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(UserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<(bool Success, string Message)> RegisterUserAsync(UserDTO userDto)
        {
            // Kiểm tra xem email đã tồn tại chưa
            var existingUser = await _userRepository.GetUserByEmailAsync(userDto.Email);
            if (existingUser != null)
            {
                return (false, "Email already exists");
            }
            var role = userDto.Role == "admin" ? "admin" : "customer";

            var newUser = new User
            {
                Email = userDto.Email,
                Password = userDto.Password,
                Firstname =  userDto.Firstname,
               Lastname=userDto.Lastname,
               Dob = userDto.Dob,   
               Phone =  userDto.Phone,
               Gender = userDto.Gender, 
               Country = userDto.Country,
                Role = "customer"

            };

            var createdUser = await _userRepository.CreateUserAsync(newUser);

            if (createdUser != null)
            {
                return (true, "User registered successfully");
            }
            return (false, "Failed to register user");
        
        }
    

        public string Login(LoginDTO loginDto, out string token)
        {
            token = null;
            var user = _userRepository.GetUserByEmail(loginDto.Email);
            if (user == null || user.Password != loginDto.Password)
            {
                return "Email or Password is incorrect";
            }

           
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("Id", user.Id.ToString()),
            new Claim("Email", user.Email)
        };

            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: signIn
            );

        
            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return "Đăng nhập thành công";
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }
    }
}
