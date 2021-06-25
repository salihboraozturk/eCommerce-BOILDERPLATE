using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using eCommerceProject.Configuration.Dto;

namespace eCommerceProject.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : eCommerceProjectAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
