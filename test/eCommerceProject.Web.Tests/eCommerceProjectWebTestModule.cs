using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using eCommerceProject.EntityFrameworkCore;
using eCommerceProject.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace eCommerceProject.Web.Tests
{
    [DependsOn(
        typeof(eCommerceProjectWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class eCommerceProjectWebTestModule : AbpModule
    {
        public eCommerceProjectWebTestModule(eCommerceProjectEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(eCommerceProjectWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(eCommerceProjectWebMvcModule).Assembly);
        }
    }
}