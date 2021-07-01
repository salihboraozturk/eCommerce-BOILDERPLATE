using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceProject.Products.Dto
{
    public class ProductViewDetailDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string CategoryName{ get; set; }
        public int QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
    }
}
