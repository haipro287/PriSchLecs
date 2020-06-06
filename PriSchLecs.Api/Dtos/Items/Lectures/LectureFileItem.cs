using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriSchLecs.Api.Dtos.Items.Lectures
{
    public class LectureFileItem: BaseItem
    {
        /// <summary>
        /// Mã bài giảng
        /// </summary>
        public int LectureId { get; set; }

        /// <summary>
        /// Mã file
        /// </summary>
        public int FileId { get; set; }
    }
}
