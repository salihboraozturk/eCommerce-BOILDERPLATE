using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceProject.Products.Dto;

namespace eCommerce.Products
{
    public interface IProductAppService:IApplicationService
    {
        Task<ProductViewDto> GetProductById(int id);
        Task<List<ProductViewDto>> GetAll();
        Task<List<ProductViewDetailDto>> GetAllProductsDetail();
        Task CreateOrEdit(CreateOrEditProductDto input);
        Task Delete(DeleteProductDto input);
    }
}
