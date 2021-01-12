using System.Threading.Tasks;
using ExamText.Configuration.Dto;

namespace ExamText.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
