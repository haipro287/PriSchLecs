using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriSchLecs.Api.Dtos.Results
{
    public class UploadResult : BaseResult
    {
        /// <summary>
        /// Id tương ứng lưu trong csdl
        /// </summary>
        public int Id { get; set; }
    }
}
