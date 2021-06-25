using System.Threading.Tasks;
using Abp.Application.Services;
using eCommerceProject.Sessions.Dto;

namespace eCommerceProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
