using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PriSchLecs.Api.Dtos.Results
{
    public class DownloadResult: BaseResult
    {
        /// <summary>
        /// file tải về
        /// </summary>
        public MemoryStream File { get; set; }

        /// <summary>
        /// tên file trả về
        /// </summary>
        public string Name { get; set; }
    }
}
