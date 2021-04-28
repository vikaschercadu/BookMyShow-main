using BookMyShow.Models;
using BookMyShow.Services.AuthenticationService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BookMyShow.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService AuthenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            AuthenticationService = authenticationService;
        }

        [Route("register")]
        public async Task<Object> Register(RegisterViewModel user)
        {
            return await AuthenticationService.Register(user);
        }

        [Route("login")]
        public async Task<Object> Login(LoginViewModel user)
        {
            return await AuthenticationService.Login(user);
        }
    }
}
