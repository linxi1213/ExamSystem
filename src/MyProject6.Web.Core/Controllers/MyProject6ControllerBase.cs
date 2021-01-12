using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MyProject6.Controllers
{
    public abstract class MyProject6ControllerBase: AbpController
    {
        protected MyProject6ControllerBase()
        {
            LocalizationSourceName = MyProject6Consts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
