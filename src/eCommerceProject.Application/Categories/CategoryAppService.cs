using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
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

namespace eCommerce.Categories
{
    public class CategoryAppService : ApplicationService, ICategoryAppService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IAbpSession _session;
        private readonly ILogger _logger; 
       
        public CategoryAppService(IRepository<Category> categoryRepository, IAbpSession session, ILogger logger)
        {
            _categoryRepository = categoryRepository;
            _session = session;
            _logger = logger;
           
        }


        public async Task<List<CategoryViewDto>> GetAll()
        {
            return await (from category in _categoryRepository.GetAll()
                          select (ObjectMapper.Map<CategoryViewDto>(category))).ToListAsync();
        }


        public async Task CreateOrEdit(CreateOrEditCategoryDto input)
        {
            if (input.Id == null)
            {
                if (await _categoryRepository.FirstOrDefaultAsync(c => c.CategoryName == input.CategoryName) != null)
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
        public async Task<CategoryViewDto> GetCategoryById(int id)
        {
            return await (from category in _categoryRepository.GetAll()
                          where category.Id == id
                          select (ObjectMapper.Map<CategoryViewDto>(category))).FirstOrDefaultAsync();
        }



        public async Task Delete(DeleteCategoryDto input)
        {
            Category category = await _categoryRepository.GetAsync((int)input.Id);
            _logger.Info("Deleting a category with given input " + input + " by user :" + _session.GetUserId());
            await _categoryRepository.DeleteAsync(category);
        }
        private async Task Create(CreateOrEditCategoryDto input)
        {
            await _categoryRepository.InsertAsync(ObjectMapper.Map<Category>(input));
        }
        private async Task Update(CreateOrEditCategoryDto input)
        {
            Category category = await _categoryRepository.GetAsync((int)input.Id);
            ObjectMapper.Map(input, category);
        }
    }
}