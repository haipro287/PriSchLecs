using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriSchLecs.Api.Dtos.Items.Categories
{
    public class CategoryLectureItem: BaseItem
    {
        /// <summary>
        /// Mã danh mục
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Mã bài giảng
        /// </summary>
        public int LectureId { get; set; }
    }
}
