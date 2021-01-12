using System.Threading.Tasks;
using MyProject6.Configuration.Dto;

namespace MyProject6.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
