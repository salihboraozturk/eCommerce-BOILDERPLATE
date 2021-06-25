using Abp.Application.Services;
using eCommerceProject.MultiTenancy.Dto;

namespace eCommerceProject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

