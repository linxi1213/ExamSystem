using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyProject6.MultiTenancy;

namespace MyProject6.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
