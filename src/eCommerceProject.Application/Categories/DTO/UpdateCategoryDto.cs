using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace eCommerceProject.Categories.DTO
{
    public class UpdateCategoryDto:EntityDto<int>
    {
        public string CategoryName { get; set; }
    }
}
