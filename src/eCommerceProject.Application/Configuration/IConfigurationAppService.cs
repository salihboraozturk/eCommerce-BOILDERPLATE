using System.Threading.Tasks;
using eCommerceProject.Configuration.Dto;

namespace eCommerceProject.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
