using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceProject.Products.Dto
{
    public class CreateOrEditProductDto: EntityDto<int?>,ICustomValidate
    {
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }

        public void AddValidationErrors(CustomValidationContext context)
        {
            if (ProductName.Length > 45 || ProductName.Length < 2 || CategoryId < 0 || QuantityPerUnit <= 0 || UnitPrice <= 0 || UnitsInStock <= 0)
            {
                context.Results.Add(new ValidationResult("Product has error."));
            }

        }
    }
}
