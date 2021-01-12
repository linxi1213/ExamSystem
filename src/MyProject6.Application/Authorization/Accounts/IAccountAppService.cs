using System.Threading.Tasks;
using Abp.Application.Services;
using MyProject6.Authorization.Accounts.Dto;

namespace MyProject6.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
