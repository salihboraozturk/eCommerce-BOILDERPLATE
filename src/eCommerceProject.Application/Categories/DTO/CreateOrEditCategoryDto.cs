using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using System.ComponentModel.DataAnnotations;

namespace eCommerceProject.Categories.DTO
{
    public class CreateOrEditCategoryDto : EntityDto<int?>, ICustomValidate
    {
        public string CategoryName { get; set; }

        public void AddValidationErrors(CustomValidationContext context)
        {
            if (CategoryName.Length > 20 || CategoryName.Length<2)
            {
                context.Results.Add(new ValidationResult("Category name has error."));
            }
        }
    }
}
