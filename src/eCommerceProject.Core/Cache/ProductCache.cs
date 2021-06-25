
using Abp.Dependency;
using Abp.Domain.Entities.Caching;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Caching;
using eCommerceProject.Models.Categories;
using eCommerceProject.Models.Products;
using System.Threading.Tasks;

namespace eCommerceProject.Cache
{
    public class ProductCache : MustHaveTenantEntityCache<Product, ProductCacheItem>, IProductCache, ITransientDependency
    {
        public ProductCache(ICacheManager cacheManager, IUnitOfWorkManager unitOfWorkManager, IRepository<Product> repository)
        : base(cacheManager, unitOfWorkManager, repository)
        {
        }
    }
    
}
