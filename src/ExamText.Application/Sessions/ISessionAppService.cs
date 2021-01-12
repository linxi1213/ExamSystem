using System.Threading.Tasks;
using Abp.Application.Services;
using ExamText.Sessions.Dto;

namespace ExamText.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
