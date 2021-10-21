using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.Identity.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> CreateAsync(User user);

        Task<User> FindByNameAsync(string userName);

        Task<SignInResult> CheckPasswordSignInAsync(User user, string password);

        Task<User> ReturnUser(User userLogin);

        Task<string> GenerateJWToken(User user);
    }
}
