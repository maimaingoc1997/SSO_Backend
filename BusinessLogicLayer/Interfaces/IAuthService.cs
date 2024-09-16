using DataAccessLayer.Models;

namespace BusinessLogicLayer.Interfaces;

public interface IAuthService
{
    Task<string> LoginAsync(LoginViewModel model);
    Task<bool> ForgotPasswordAsync(ForgotPasswordViewModel model);
}