using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.Identity;
using Examples.Charge.Domain.Aggregates.Identity.Interfaces;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class UserFacade : IUserFacade
    {
        private IUserService _userService;
        private IMapper _mapper;

        public UserFacade(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<UserResponse> CreateAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            var result = await _userService.CreateAsync(user);

            var userToReturn = _mapper.Map<UserDto>(user);

            var userResponse = new UserResponse
            {
                IdentityResult = result.Succeeded,
                User = userToReturn
            };

            return userResponse;
        }

        public async Task<UserResponse> Login(UserLoginDto userLogin)
        {
            var user = _mapper.Map<User>(userLogin);

            user = await _userService.FindByNameAsync(user.UserName);

            var result = await _userService.CheckPasswordSignInAsync(user, userLogin.Password);

            if (result.Succeeded)
            {
                var appUser = await _userService.ReturnUser(user);

                var userToReturn = _mapper.Map<UserLoginDto>(appUser);

                return new UserResponse
                {
                    SignResult = result.Succeeded,
                    Token = _userService.GenerateJWToken(appUser).Result,
                    UserLogin = userToReturn
                };
            }
            else
            {
                return new UserResponse
                {
                    SignResult = result.Succeeded
                };
            }
        }
    }
}
