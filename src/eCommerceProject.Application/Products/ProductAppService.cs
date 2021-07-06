using Abp.Application.Services;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using Castle.Core.Logging;
using eCommerce.Categories;
using eCommerceProject.Cache;
using eCommerceProject.Models.Products;
using eCommerceProject.Products.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Extensions;
using eCommerceProject.Authorization;
using eCommerceProject.Models.Categories;

namespace eCommerce.Products
{
    [AbpAuthorize(PermissionNames.Pages_Products)]
    public class ProductAppService : ApplicationService, IProductAppService, ITransientDependency
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IAbpSession _session;
        private readonly ILogger _logger;
        private readonly IProductCache _productCache;
        private readonly IRepository<Category> _categoryRepository;  
        public ProductAppService(IRepository<Product> productRepository, IAbpSession session, ILogger logger,
            IProductCache productCache, IRepository<Category> categoryRepository)
        {
            _productRepository = productRepository;
            _session = session;
            _logger = logger;
            _productCache = productCache;
            _categoryRepository = categoryRepository;
        }
        [AbpAuthorize(PermissionNames.List)]
        public async Task<ProductViewDto> GetProductById(int id)
        {
            ProductViewDto user = ObjectMapper.Map<ProductViewDto>(await _productCache.GetAsync(id));
            if (user != null)
            {
                return user;
            }
            else
            {
                return await GetProductByIdFromDB(id);
            }
        }
        [AbpAuthorize(PermissionNames.List)]
        public async Task<List<ProductViewDto>> GetAll()
        {
            return await (from product in _productRepository.GetAll()
                select (ObjectMapper.Map<ProductViewDto>(product))).ToListAsync();
        }
        [AbpAuthorize(PermissionNames.List)]
        public async Task<List<ProductViewDetailDto>> GetAllProductsDetail()
        {
            var result = from p in _productRepository.GetAll().ToList()
                join c in _categoryRepository.GetAll().ToList()
                    on p.CategoryId equals c.Id
                select new ProductViewDetailDto
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    CategoryName = c.CategoryName,
                    QuantityPerUnit = p.QuantityPerUnit,
                    UnitPrice = p.UnitPrice,
                    UnitsInStock = p.UnitsInStock
                };
            return result.ToList();
        }
        [AbpAuthorize(PermissionNames.Manipulation)]
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

        [AbpAuthorize(PermissionNames.Manipulation)] 
        public async Task Delete(DeleteProductDto input)
        {
            Product product = await _productRepository.GetAsync((int) input.Id);
            _logger.Info("Deleting  a new product with given input " + input + " by user :" + _session.GetUserId());
            await _productRepository.DeleteAsync(product);
        }

        private async Task<ProductViewDto> GetProductByIdFromDB(int id)
        {
            return await (from product in _productRepository.GetAll()
                where product.Id == id
                select (ObjectMapper.Map<ProductViewDto>(product))).FirstOrDefaultAsync();
        }


        private async Task Create(CreateOrEditProductDto input)
        {
            await _productRepository.InsertAsync(ObjectMapper.Map<Product>(input));
        }

        private async Task Update(CreateOrEditProductDto input)
        {
            Product product = await _productRepository.GetAsync((int) input.Id);
            ObjectMapper.Map(input, product);
        }
    }
}