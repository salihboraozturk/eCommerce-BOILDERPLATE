using Abp.Authorization;
using eCommerceProject.Authorization.Roles;
using eCommerceProject.Authorization.Users;

namespace eCommerceProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
