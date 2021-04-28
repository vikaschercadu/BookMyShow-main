using BookMyShow.Models;
using BookMyShow.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.Services.AuthenticationService
{
    public class AuthenticationService:  ControllerBase, IAuthenticationService
    {
        private string SecurityKey { get; }
        private UserManager<ApplicationUser> UserManager { get; }
        private SignInManager<ApplicationUser> SignInManager { get; }
        public AuthenticationService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
                              IConfiguration configuration)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            SecurityKey = configuration["ApplicationSettings:JWT_SeceretKey"].ToString();
        }

        public async Task<object> Register(RegisterViewModel registerCreds)
        {
            var user = new ApplicationUser { UserName = registerCreds.EmailId, Email = registerCreds.EmailId, FullName=registerCreds.Name };
            registerCreds.Role = "Customer";
            var Result = await UserManager.CreateAsync(user, registerCreds.Password);


            await UserManager.AddToRoleAsync(user, registerCreds.Role);

            if (Result.Succeeded)
            {
                var result = await SignInManager.PasswordSignInAsync(user, registerCreds.Password, false, false);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
            }
            return Result.Errors;
        }

        public async Task<Object> Login(LoginViewModel loginCreds)
        {
            var user = await UserManager.FindByEmailAsync(loginCreds.EmailId);

            TokenViewModel Token = new TokenViewModel { Name=user.FullName , UserId=user.Id};

            if (user != null && await UserManager.CheckPasswordAsync(user, loginCreds.Password))
            {
                var signInResult = await SignInManager.PasswordSignInAsync(user, loginCreds.Password, false, false);
                var role = await UserManager.GetRolesAsync(user);
                IdentityOptions options = new IdentityOptions();

                var TokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                            new Claim("UserId",user.Id.ToString()),
                            new Claim(options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
                        }),
                    Expires = DateTime.Now.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.SecurityKey)),
                    SecurityAlgorithms.HmacSha256)
                };

                var TokenHandler = new JwtSecurityTokenHandler();
                var SecurityToken = TokenHandler.CreateToken(TokenDescriptor);
                Token.AccessToken = TokenHandler.WriteToken(SecurityToken);
                return Ok(new { Token });
            }
            else
            {
                return BadRequest();
            }           
        }
    }
}
