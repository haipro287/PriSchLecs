using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PriSchLecs.Api.Domains.BaseEntities;
using PriSchLecs.Api.Domains.Lectures;

namespace PriSchLecs.Api.Domains.Categories
{
    public class CategoryLecture: BaseEntity
    {
        /// <summary>
        /// Mã danh mục
        /// </summary>
        [Key]
        [Required]
        public int CategoryId { get; set; }

        /// <summary>
        /// Mã bài giảng
        /// </summary>
        [Key]
        [Required]
        public int LectureId { get; set; }

        /// <summary>
        /// Thực thể danh mục
        /// </summary>
        public virtual Category Category { get; set;}

        /// <summary>
        /// Thực thể bài giảng 
        /// </summary>
        public virtual Lecture Lecture { get; set; }
    }
}
