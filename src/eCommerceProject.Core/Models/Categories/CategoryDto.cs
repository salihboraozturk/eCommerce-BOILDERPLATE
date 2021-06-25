using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace eCommerceProject.Models.Categories
{
    [AutoMapFrom(typeof(Category))]
    public class CategoryDto : EntityDto<int>
    {
        public string CategoryName { get; set; }

    }
}
