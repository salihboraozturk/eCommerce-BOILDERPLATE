using Abp.Dependency;
using Abp.Domain.Entities.Caching;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Caching;
using eCommerceProject.Models.Categories;
using System.Threading.Tasks;

namespace eCommerceProject.Cache
{
    public class CategoryCache : MustHaveTenantEntityCache<Category, CategoryCacheItem>, ICategoryCache,
        ITransientDependency
    {
        public CategoryCache(ICacheManager cacheManager, IUnitOfWorkManager unitOfWorkManager,
            IRepository<Category> repository)
            : base(cacheManager, unitOfWorkManager, repository)
        {
        }
    }
}