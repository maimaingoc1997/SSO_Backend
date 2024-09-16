using System.Security.Claims;
using System.Text;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessLogicLayer.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly string _secretKey;
    private readonly IConfiguration _configuration;

    public AuthService(AppDbContext context, string secretKey, IConfiguration configuration)
    { 
        var jwtSecretKey = configuration["Jwt:SecretKey"];

        _context = context;
         _secretKey = jwtSecretKey ?? throw new ArgumentNullException(nameof(jwtSecretKey), "Jwt:SecretKey configuration value is null");
        _configuration = configuration;
       }

    public async Task<string> LoginAsync(LoginViewModel model)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ForgotPasswordAsync(ForgotPasswordViewModel model)
    {
        throw new NotImplementedException();
    }
}