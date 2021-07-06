
using Abp.Authorization;

using Abp.ObjectMapping;
using Abp.Runtime.Session;
using Abp.UI;
using Castle.Core.Logging;
using eCommerceProject;
using eCommerceProject.Authorization;
using eCommerceProject.Cache;
using eCommerceProject.Categories.DTO;
using eCommerceProject.Models.Categories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceProject.Products.Dto;
using Abp.Application.Services;
using Abp.Domain.Repositories;

namespace eCommerce.Categories
{
    [AbpAuthorize(PermissionNames.Pages_Categories)]
    public class CategoryAppService : ApplicationService, ICategoryAppService
    {
        private readonly IRepository<Category> _repository;
        private readonly IAbpSession _session;
        private readonly ILogger _logger;
        private readonly ICategoryCache _categoryCache;

        public CategoryAppService(IRepository<Category> repository, IAbpSession session, ILogger logger,
            ICategoryCache categoryCache)
        {
            _repository = repository;
            _session = session;
            _logger = logger;
            _categoryCache = categoryCache;
        }


        [AbpAuthorize(PermissionNames.List)]
        public async Task<CategoryViewDto> GetCategoryById(int id)
        {
            CategoryViewDto category = ObjectMapper.Map<CategoryViewDto>(await _categoryCache.GetAsync(id));
            if (category != null)
            {
                return category;
            }
            else
            {
                return await GetCategoryByIdFromDb(id);
            }
        }
        [AbpAuthorize(PermissionNames.List)]
        public async Task<List<CategoryViewDto>> GetAll()
        {
            return await (from category in _repository.GetAll()
                          select (ObjectMapper.Map<CategoryViewDto>(category))).ToListAsync();
        }

        [AbpAuthorize(PermissionNames.Manipulation)]
        public async Task CreateOrEdit(CreateOrEditCategoryDto input)
        {
            if (input.Id == null)
            {
                if (await _repository.FirstOrDefaultAsync(c => c.CategoryName == input.CategoryName) != null)
                {
                    throw new UserFriendlyException("InsertFailed", "CategoryAlreadyExist");
                    // throw new UserFriendlyException(L("InsertFailed"), L("CategoryAlreadyExist"));
                }

                _logger.Info("Creating a new category with given input " + input + " by user :" + _session.GetUserId());
                await Create(input);
            }

            else
            {
                _logger.Info("Updating a category with given input " + input + " by user :" + _session.GetUserId());
                await Update(input);
            }
        }
        [AbpAuthorize(PermissionNames.Manipulation)]
        public async Task Delete(DeleteCategoryDto input)
        {
            Category category = await _repository.GetAsync((int)input.Id);
            _logger.Info("Deleting a category with given input " + input + " by user :" + _session.GetUserId());
            await _repository.DeleteAsync(category);
        }


        private async Task<CategoryViewDto> GetCategoryByIdFromDb(int id)
        {
            return await (from category in _repository.GetAll()
                          where category.Id == id
                          select (ObjectMapper.Map<CategoryViewDto>(category))).FirstOrDefaultAsync();
        }



        private async Task Create(CreateOrEditCategoryDto input)
        {
            await _repository.InsertAsync(ObjectMapper.Map<Category>(input));
        }

        private async Task Update(CreateOrEditCategoryDto input)
        {
            Category category = await _repository.GetAsync((int)input.Id);
            ObjectMapper.Map(input, category);
        }
    }
}
