using Abp.Authorization;
using MyProject6.Authorization.Roles;
using MyProject6.Authorization.Users;

namespace MyProject6.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
