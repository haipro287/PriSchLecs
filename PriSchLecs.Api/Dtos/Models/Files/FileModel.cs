using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriSchLecs.Api.Dtos.Models.Files
{
    public class FileModel
    {
        /// <summary>
        /// File được upload
        /// </summary>
        public IFormFile File { get; set; }


    }
}
