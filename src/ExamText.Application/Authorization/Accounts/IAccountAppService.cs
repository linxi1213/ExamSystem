using System.Threading.Tasks;
using Abp.Application.Services;
using ExamText.Authorization.Accounts.Dto;

namespace ExamText.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
