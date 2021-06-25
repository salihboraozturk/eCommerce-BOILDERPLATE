using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using eCommerceProject.Configuration;
using eCommerceProject.Web;

namespace eCommerceProject.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class eCommerceProjectDbContextFactory : IDesignTimeDbContextFactory<eCommerceProjectDbContext>
    {
        public eCommerceProjectDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<eCommerceProjectDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            eCommerceProjectDbContextConfigurer.Configure(builder, configuration.GetConnectionString(eCommerceProjectConsts.ConnectionStringName));

            return new eCommerceProjectDbContext(builder.Options);
        }
    }
}
