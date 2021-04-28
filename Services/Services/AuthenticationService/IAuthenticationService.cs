using BookMyShow.Models;
using System;
using System.Threading.Tasks;

namespace BookMyShow.Services.AuthenticationService
{
    public interface IAuthenticationService
    {
        Task<Object> Register(RegisterViewModel user);
        Task<Object> Login(LoginViewModel user);
    }
}
