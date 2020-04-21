using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriSchLecs.Api.Domains.BaseEntities
{
    public class BaseEntity
    {
        /// <summary>
        /// Id của thực thể
        /// </summary>
        public int Id { get; set; }                 

        /// <summary>
        /// Ngày tạo thực thể
        /// </summary>
        public DateTimeOffset? CreatedTime { get; set; }

        /// <summary>
        /// Ngày cập nhật thực thể
        /// </summary>
        public DateTimeOffset? UpdatedTime { get; set; }

        /// <summary>
        /// Thực thể đã bị xóa chưa?
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
