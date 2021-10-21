using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IUserFacade
    {
        Task<UserResponse> CreateAsync(UserDto userDto);

        Task<UserResponse> Login(UserLoginDto userLogin);
    }
}
