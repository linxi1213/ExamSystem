using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ExamText.Configuration.Dto;

namespace ExamText.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ExamTextAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
