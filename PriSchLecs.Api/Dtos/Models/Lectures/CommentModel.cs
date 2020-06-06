using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriSchLecs.Api.Dtos.Models.Lectures
{
    public class CommentModel
    {
        /// <summary>
        /// Nội dung bình luận
        /// </summary>
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
        public int LectureId { get; set; }

        /// <summary>
        /// Mã bình luận cha
        /// </summary>
        public int? ParentId { get; set; }
    }
}
