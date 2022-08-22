using FlightsManager.Models;

namespace FlightsManager.Interfaces
{
    public interface IIdentityRepository
    {
        Task<Response> RegisterNewUser(string Role, RegisterModel model);
        Task<LoginResponse> LoginUser(LoginModel model);
        Task<User> GetUserInfo(string userId);
    }
}
