using Abp.Authorization;
using ExamText.Authorization.Roles;
using ExamText.Authorization.Users;

namespace ExamText.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
