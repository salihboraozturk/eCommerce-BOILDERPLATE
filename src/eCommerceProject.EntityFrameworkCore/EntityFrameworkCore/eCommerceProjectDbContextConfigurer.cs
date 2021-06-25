using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace eCommerceProject.EntityFrameworkCore
{
    public static class eCommerceProjectDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<eCommerceProjectDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<eCommerceProjectDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
