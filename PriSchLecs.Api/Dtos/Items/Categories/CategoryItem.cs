using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriSchLecs.Api.Dtos.Items.Categories
{
    public class CategoryItem: BaseItem
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
