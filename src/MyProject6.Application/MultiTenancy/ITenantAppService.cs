using Abp.Application.Services;
using MyProject6.MultiTenancy.Dto;

namespace MyProject6.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

