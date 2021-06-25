using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using eCommerceProject.Configuration;

namespace eCommerceProject.Web.Host.Startup
{
    [DependsOn(
       typeof(eCommerceProjectWebCoreModule))]
    public class eCommerceProjectWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public eCommerceProjectWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(eCommerceProjectWebHostModule).GetAssembly());
        }
    }
}
