using AutoMapper;
using eCommerceProject.Cache;
using eCommerceProject.Models.Categories;

namespace eCommerceProject.Categories.DTO
{
    public class CategoryMapProfile : Profile
    {
        public CategoryMapProfile()
        {
            CreateMap<Category, CategoryViewDto>();
            CreateMap<CategoryViewDto, Category>();
            CreateMap<CreateOrEditCategoryDto, Category>();
            CreateMap<Category, CreateOrEditCategoryDto>();
            CreateMap<Category, CategoryCacheItem>();
            CreateMap<CategoryCacheItem, Category>();
            CreateMap<CategoryCacheItem, CategoryViewDto>();
            CreateMap<CategoryViewDto, CategoryCacheItem>();
        }
    }
}
