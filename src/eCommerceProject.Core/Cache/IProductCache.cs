using Abp.Domain.Entities.Caching;
using eCommerceProject.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceProject.Cache
{
    public interface IProductCache : IMultiTenancyEntityCache<ProductCacheItem>
    {
    }
}
