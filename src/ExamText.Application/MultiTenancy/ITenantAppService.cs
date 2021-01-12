using Abp.Application.Services;
using ExamText.MultiTenancy.Dto;

namespace ExamText.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

