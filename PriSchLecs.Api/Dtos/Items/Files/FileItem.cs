using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriSchLecs.Api.Dtos.Items.Files
{
    public class FileItem: BaseItemInt
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
