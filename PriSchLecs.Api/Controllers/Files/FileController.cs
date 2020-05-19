using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PriSchLecs.Api.Domains.Files;
using PriSchLecs.Api.Dtos.Models.Files;
using PriSchLecs.Api.Infrastructure.SmartTable;
using PriSchLecs.Api.Infrastructures.Services.Files;

namespace PriSchLecs.Api.Controllers.Files
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService FileService;

        public FileController(IFileService fileService)
        {
            FileService = fileService;
        }

        /// <summary>
        /// API đăng tải file lên server
        /// </summary>
        /// <param name="model">file</param>
        /// <returns></returns>
        [HttpPost("Upload")]
        public async Task<IActionResult> Upload([FromForm]FileModel model)
        {
            var result = await FileService.Upload(model);
            return Ok(result);
        }

        /// <summary>
        /// API tải file từ server
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Download/{id}")]
        public async Task<IActionResult> Download(int id)
        {
            var result = await FileService.Download(id);
            if (result.File == null)
            {
                return Ok(result);
            }
            result.File.Position = 0;
            return File(result.File, "application/octet-stream", result.Name);
        }

        /// <summary>
        /// API lấy danh sách file
        /// </summary>
        /// <param name="param">tham số dạng smart table gồm tên, ngày tạo, phân trang, sắp xếp</param>
        /// <returns></returns>
        [HttpPost("Search")]
        public async Task<IActionResult> Search(SmartTableParam param)
        {
            var result = await FileService.Search(param);
            return Ok(result);

        }

        /// <summary>
        /// APi xóa file 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await FileService.Delete(id);
            return Ok(result);
        }
    }
}