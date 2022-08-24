using FlightsManager.Domain.Models;
using System.Threading.Tasks;

namespace FlightsManager.Application.Contracts
{
    public interface IIdentityRepository
    {
        Task<Response> RegisterNewUser(string Role, RegisterModel model);
        Task<LoginResponse> LoginUser(LoginModel model);
        Task<User> GetUserInfo(string userId);
    }
}
