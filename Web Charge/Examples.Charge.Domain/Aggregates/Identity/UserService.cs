using Examples.Charge.Domain.Aggregates.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.Identity
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IdentityResult> CreateAsync(User user) => (await _userRepository.CreateAsync(user));

        public async Task<User> FindByNameAsync(string userName) => (await _userRepository.FindByNameAsync(userName));

        public async Task<SignInResult> CheckPasswordSignInAsync(User user, string password) => (await _userRepository.CheckPasswordSignInAsync(user, password));

        public async Task<User> ReturnUser(User userLogin) => (await _userRepository.ReturnUser(userLogin));

        public async Task<string> GenerateJWToken(User user) => (await _userRepository.GenerateJWToken(user));
    }
}
