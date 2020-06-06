using Microsoft.AspNetCore.Mvc;
using PriSchLecs.Api.Dtos.Models.Lectures;
using PriSchLecs.Api.Infrastructures.Services.Lectures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriSchLecs.Api.Controllers.Lectures
{
    [ApiController]
    [Route("api/[controller]")]
    public class LectureFileController: ControllerBase
    {
        private readonly ILectureFileService LectureFileService;

        public LectureFileController(ILectureFileService lectureFileService)
        {
            LectureFileService = lectureFileService;
        }

        /// <summary>
        /// API Tạo liên kết bài giảng - file
        /// </summary>
        /// <param name="model">Model liên kết</param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]LectureFileModel model)
        {
            var result = await LectureFileService.Create(model);
            return Ok(result);
        }

        /// <summary>
        /// API xóa liên kết bài giảng - file
        /// </summary>
        /// <param name="lectureId">Id của bài giảng</param>
        /// <param name="fileId">Id của file</param>
        /// <returns></returns>
        [HttpDelete("Delete/{lectureId}-{fileId}")]
        public async Task<IActionResult> Delete(int lectureId, int fileId)
        {
            var result = await LectureFileService.Delete(lectureId, fileId);
            return Ok(result);
        }

        /// <summary>
        /// API lấy file theo Id bài giảng
        /// </summary>
        /// <param name="lectureId">Id bài giảng</param>
        /// <returns></returns>
        [HttpGet("GetFileByLectureId/{lectureId}")]
        public async Task<IActionResult> GetFileByLectureId(int lectureId)
        {
            var result = LectureFileService.GetFile(lectureId);
            return Ok(result);
        }

        /// <summary>
        /// API lấy bài giảng theo id file 
        /// </summary>
        /// <param name="fileId">id file</param>
        /// <returns></returns>
        [HttpGet("GetLectureByFileId/{fileId}")]
        public async Task<IActionResult> GetLectureByCategoryId(int fileId)
        {
            var result = LectureFileService.GetLecture(fileId);
            return Ok(result);
        }
    }
}
