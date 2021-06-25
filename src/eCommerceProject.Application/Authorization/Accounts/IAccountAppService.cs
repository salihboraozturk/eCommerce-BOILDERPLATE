using System.Threading.Tasks;
using Abp.Application.Services;
using eCommerceProject.Authorization.Accounts.Dto;

namespace eCommerceProject.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
