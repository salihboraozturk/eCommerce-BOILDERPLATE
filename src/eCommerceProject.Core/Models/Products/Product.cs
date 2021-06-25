using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Runtime.Validation;
using eCommerceProject.Authorization.Users;
using eCommerceProject.Models.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceProject.Models.Products
{
    public class Product:Entity<int>,IMustHaveTenant,ISoftDelete,IFullAudited<User>
    {
        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int QuantityPerUnit { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public short UnitsInStock { get; set; }
        [Required]
        public int TenantId { get; set; }
        public bool IsDeleted { get; set; }
        public User CreatorUser { get; set; }
        public User LastModifierUser { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public User DeleterUser { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }

       
    }
}
