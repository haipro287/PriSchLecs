using PriSchLecs.Api.Domains.BaseEntities;
using PriSchLecs.Api.Domains.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriSchLecs.Api.Domains.Lectures
{
    public class LectureFile : BaseEntity
    {
        /// <summary>
        /// Mã bài giảng
        /// </summary>
        public int LectureId { get; set; }

        /// <summary>
        /// Mã file
        /// </summary>
        public int FileId { get; set; }

        /// <summary>
        /// Bài giảng
        /// </summary>
        public virtual Lecture Lecture { get; set; }

        /// <summary>
        /// File
        /// </summary>
        public virtual File File { get; set; }
    }
}
