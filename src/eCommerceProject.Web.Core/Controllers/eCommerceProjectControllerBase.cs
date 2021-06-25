using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace eCommerceProject.Controllers
{
    public abstract class eCommerceProjectControllerBase: AbpController
    {
        protected eCommerceProjectControllerBase()
        {
            LocalizationSourceName = eCommerceProjectConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
