using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PriSchLecs.Api.Domains.BaseEntities;

namespace PriSchLecs.Api.Domains.Lectures
{
    public class Comment : BaseEntityByInt
    {

        #region Fields
        /// <summary>
        /// Nội dung bình luận
        /// </summary>
        [Required]
        public string Content { get; set; }

        /// <summary>
        /// Tên người dùng
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Mã bài giảng
        /// </summary>
        [Required]
        public int LectureId { get; set; }

        /// <summary>
        /// Mã bình luận cha
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// Thực thể bài giảng
        /// </summary>
        public virtual Lecture Lecture { get; set; }

        /// <summary>
        /// Thực thể bình luận cha
        /// </summary>
        public virtual Comment Parent { get; set; }
        #endregion
    }
}
