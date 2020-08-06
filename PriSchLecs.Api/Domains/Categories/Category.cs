using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PriSchLecs.Api.Domains.BaseEntities;

namespace PriSchLecs.Api.Domains.Categories
{
    public class Category: BaseEntityByInt
    {
        /// <summary>
        /// Tên danh mục
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Mã danh mục cha
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// Thực thể cha
        /// </summary>
        public virtual Category Parent { get; set; }

        /// <summary>
        /// Tập thực thể con
        /// </summary>
        public virtual ICollection<Category> Children { get; set; }
    }
}
