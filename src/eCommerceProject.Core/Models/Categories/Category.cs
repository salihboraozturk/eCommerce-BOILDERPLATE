
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Runtime.Validation;
using eCommerceProject.Authorization.Users;
using eCommerceProject.Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceProject.Models.Categories
{
   
    public class Category:Entity<int>, IMustHaveTenant, ISoftDelete, IFullAudited<User>
    {
       
        public string CategoryName { get; set; }
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
