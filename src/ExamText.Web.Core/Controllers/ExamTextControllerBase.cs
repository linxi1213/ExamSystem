using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ExamText.Controllers
{
    public abstract class ExamTextControllerBase: AbpController
    {
        protected ExamTextControllerBase()
        {
            LocalizationSourceName = ExamTextConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
