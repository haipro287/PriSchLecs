using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PriSchLecs.Api.Domains.BaseEntities;

namespace PriSchLecs.Api.Domains.Files
{
    public class File: BaseEntity
    {
        /// <summary>
        /// Tên file
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Đường dẫn
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Ổ
        /// </summary>
        public string Drive { get; set; }

        /// <summary>
        /// Tên miền
        /// </summary>
        public string Domain { get; set; }
    }
}
