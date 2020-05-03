using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriSchLecs.Api.Dtos.Models.Categories
{
    public class CategoryLectureModel: BaseModel
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
