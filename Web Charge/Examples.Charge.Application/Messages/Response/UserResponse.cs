using Examples.Charge.Application.Common.Messages;
using Examples.Charge.Application.Dtos;

namespace Examples.Charge.Application.Messages.Response
{
    public class UserResponse : BaseResponse
    {
        public UserDto User { get; set; }

        public bool IdentityResult { get; set; }

        public bool SignResult { get; set; }

        public string Token { get; set; }

        public UserLoginDto UserLogin { get; set; }
    }
}
