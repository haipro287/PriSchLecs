using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriSchLecs.Api.Dtos.Items
{
    public class BaseItem
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTimeOffset? CreatedTime { get; set; }

        public string CreatedTimeDisplay => CreatedTime.HasValue ? CreatedTime.Value.ToString("dd/MM/yyyy HH:mm") : "";

        /// <summary>
        /// Ngày cập nhật
        /// </summary>
        public DateTimeOffset? UpdatedTime { get; set; }

        public string UpdatedTimeDisplay => UpdatedTime.HasValue ? UpdatedTime.Value.ToString("dd/MM/yyyy HH:mm") : "";
    }
}
