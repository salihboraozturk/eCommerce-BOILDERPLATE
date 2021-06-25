using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using eCommerceProject.Authorization.Roles;
using eCommerceProject.Authorization.Users;
using eCommerceProject.MultiTenancy;
using eCommerceProject.Models.Products;
using eCommerceProject.Models.Categories;

namespace eCommerceProject.EntityFrameworkCore
{
    public class eCommerceProjectDbContext : AbpZeroDbContext<Tenant, Role, User, eCommerceProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public eCommerceProjectDbContext(DbContextOptions<eCommerceProjectDbContext> options)
            : base(options)
        {
        }
    }
}
