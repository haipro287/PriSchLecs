using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriSchLecs.Api.Dtos.Results
{
    public class CreateOrUpdateResult: BaseResult
    {
        /// <summary>
        /// Id của đối tượng vừa tạo
        /// </summary>
        public int Id { get; set; }
    }
}
