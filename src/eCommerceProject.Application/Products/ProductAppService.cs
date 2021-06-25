using Abp.Application.Services;
using Abp.Authorization;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using Abp.Runtime.Caching;
using Abp.Runtime.Session;
using Abp.UI;
using Castle.Core.Logging;
using eCommerceProject.Authorization;
using eCommerceProject.Cache;
using eCommerceProject.Models.Products;
using eCommerceProject.Products.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eCommerce.Products
{
    public class ProductAppService : ApplicationService,IProductAppService, ITransientDependency
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IAbpSession _session;
        private readonly ILogger _logger;
        private readonly IProductCache _productCache;
        public ProductAppService(IRepository<Product> productRepository, IAbpSession session, ILogger logger, IProductCache productCache)
        {
            _productRepository = productRepository;
            _session = session;
            _logger = logger;
            _productCache = productCache;

        }

        public string GetPersonNameById(int id)
        {
            return _productCache[id].ProductName; //alternative: _personCache.Get(id).Name;
        }

        public async Task<List<ProductViewDto>> GetAll()
        {
            return await (from product in _productRepository.GetAll()
                          select (ObjectMapper.Map<ProductViewDto>(product))).ToListAsync();
        }
        public async Task<ProductViewDto> GetProductById(int id)
        {
            return await (from product in _productRepository.GetAll()
                          where product.Id == id
                          select (ObjectMapper.Map<ProductViewDto>(product))).FirstOrDefaultAsync();
        }

       


        public async Task CreateOrEdit(CreateOrEditProductDto input)
        {
            if (input.Id == null)
            {
                if (await _productRepository.FirstOrDefaultAsync(c => c.ProductName == input.ProductName) != null)
                {
                    throw new UserFriendlyException("InsertFailed", "ProductAlreadyExist");
                    // throw new UserFriendlyException(L("InsertFailed"), L("CategoryAlreadyExist"));
                }
                _logger.Info("Creating a new product with given input " + input + " by user :" + _session.GetUserId());
                await Create(input);
            }
            else
            {
                _logger.Info("Updating  a new product with given input " + input + " by user :" + _session.GetUserId());
                await Update(input);
            }
        }
        public async Task Delete(DeleteProductDto input)
        {
            Product product = await _productRepository.GetAsync((int)input.Id);
            _logger.Info("Deleting  a new product with given input " + input + " by user :" + _session.GetUserId());
            await _productRepository.DeleteAsync(product);
        }
      
        private async Task Create(CreateOrEditProductDto input)
        {
           await _productRepository.InsertAsync(ObjectMapper.Map<Product>(input));
        }

        private async Task Update(CreateOrEditProductDto input)
        {
            Product product = await _productRepository.GetAsync((int)input.Id);
            ObjectMapper.Map(input, product);
        }
    }
}
