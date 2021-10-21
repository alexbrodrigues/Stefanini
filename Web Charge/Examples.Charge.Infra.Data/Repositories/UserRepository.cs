using Examples.Charge.Domain.Aggregates.Identity;
using Examples.Charge.Domain.Aggregates.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserRepository(IConfiguration config, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            _config = config;
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateAsync(User user)
        {
            var result = await _userManager.CreateAsync(user, user.PasswordHash);

            return result;
        }

        public async Task<User> FindByNameAsync(string userName) => (await _userManager.FindByNameAsync(userName));

        public async Task<SignInResult> CheckPasswordSignInAsync(User user, string password) => (await _signInManager.CheckPasswordSignInAsync(user, password, false));

        public async Task<User> ReturnUser(User userLogin) => (await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == userLogin.UserName.ToUpper()));

        public async Task<string> GenerateJWToken(User user)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName)
        };

            var roles = await _userManager.GetRolesAsync(user);

            if(roles.Count > 0)
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }

            var key = new SymmetricSecurityKey(Encoding.ASCII
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            //  var tokenJwt = new SecurityTokenDescriptor
            //    {
            //        Subject = new ClaimsIdentity(userClaims),
            //        Expires = DateTime.UtcNow.AddMinutes(15),
            //        //Expires = DateTime.Now.AddMinutes(15),
            //        SigningCredentials = creds
            //    };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
