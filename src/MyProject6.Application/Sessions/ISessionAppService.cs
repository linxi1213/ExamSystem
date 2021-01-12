using System.Threading.Tasks;
using Abp.Application.Services;
using MyProject6.Sessions.Dto;

namespace MyProject6.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();


        string SayHello();
    }
}
