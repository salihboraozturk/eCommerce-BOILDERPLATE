using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace eCommerceProject.Authorization
{
    public class eCommerceProjectAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Products, L("Products"));
            context.CreatePermission(PermissionNames.Pages_Categories, L("Categories"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Manipulation, L("Manipulation"));
            context.CreatePermission(PermissionNames.List, L("List"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, eCommerceProjectConsts.LocalizationSourceName);
        }
    }
}
