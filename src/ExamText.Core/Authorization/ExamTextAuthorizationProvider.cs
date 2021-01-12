using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace ExamText.Authorization
{
    public class ExamTextAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {        
            var pages = context.CreatePermission(PermissionNames.Pages,L("Pages"));

            var tenants = pages.CreateChildPermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            var examinees = pages.CreateChildPermission(PermissionNames.Pages_Examinees, L("Examinees"));

            var examquestion = pages.CreateChildPermission(PermissionNames.Pages_Exam_Questions,L("ExamQuestion"));

            var roles = pages.CreateChildPermission(PermissionNames.Pages_Roles, L("Roles"));
            roles.CreateChildPermission(PermissionNames.Pages_Roles_Get, L("GetRoles"));

            var users = pages.CreateChildPermission(PermissionNames.Pages_Users, L("Users"));
            users.CreateChildPermission(PermissionNames.Pages_Users_Create, L("CreateUser"));
            users.CreateChildPermission(PermissionNames.Pages_Users_Update, L("UpdataUser"));
            users.CreateChildPermission(PermissionNames.Pages_Users_Delete, L("DeteleUser"));
            users.CreateChildPermission(PermissionNames.Pages_Users_ChangePassword, L("ChangeUserPassword"));
            users.CreateChildPermission(PermissionNames.Pages_Users_Get, L("GetUser"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ExamTextConsts.LocalizationSourceName);
        }
    }
}
