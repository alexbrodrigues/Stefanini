using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.Identity.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> CreateAsync(User user);

        Task<User> FindByNameAsync(string userNamen);

        Task<SignInResult> CheckPasswordSignInAsync(User user, string password);

        Task<User> ReturnUser(User userLogin);

        Task<string> GenerateJWToken(User user);
    }
}
