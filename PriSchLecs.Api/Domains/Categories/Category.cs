using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PriSchLecs.Api.Domains.BaseEntities;

namespace PriSchLecs.Api.Domains.Categories
{
    public class Category: BaseEntity
    {
        /// <summary>
        /// Tên danh mục
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Mã danh mục cha
        /// </summary>
        public int? ParentId { get; set; }
    }
}
