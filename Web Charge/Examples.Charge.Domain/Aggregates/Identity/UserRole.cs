using Microsoft.AspNetCore.Identity;

namespace Examples.Charge.Domain.Aggregates.Identity
{
    public class UserRole : IdentityUserRole<int>
    {
        public User Usuario { get; set; }
        public Role Role { get; set; }
    }
}
