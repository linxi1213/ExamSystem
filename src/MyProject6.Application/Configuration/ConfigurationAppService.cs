using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MyProject6.Configuration.Dto;

namespace MyProject6.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MyProject6AppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
