using AutoMapper;
using eCommerceProject.Cache;
using eCommerceProject.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceProject.Products.Dto
{
    public class ProductMapProfile:Profile
    {
        public ProductMapProfile()
        {
            CreateMap<Product, ProductViewDto>();
            CreateMap<ProductViewDto, Product>();
            CreateMap<Product, CreateOrEditProductDto>();
            CreateMap<CreateOrEditProductDto, Product>();
            CreateMap<Product, ProductCacheItem>();
            CreateMap<ProductCacheItem, Product>();

        }
           
    }
}
