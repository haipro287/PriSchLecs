using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PriSchLecs.Api.Dtos.Models.Lectures;
using PriSchLecs.Api.Infrastructure.SmartTable;
using PriSchLecs.Api.Infrastructures.Services.Lectures;

namespace PriSchLecs.Api.Controllers.Lectures
{
    [ApiController]
    [Route("api/[controller]")]
    public class LectureController : ControllerBase
    {
        private readonly ILectureService LectureService;

        public LectureController(ILectureService lectureService)
        {
            LectureService = lectureService;
        }

        /// <summary>
        /// API tìm kiếm bài giảng
        /// </summary>
        /// <param name="param">Tham số smartTable</param>
        /// <returns></returns>
        [HttpPost("Search")]
        public async Task<IActionResult> Search([FromBody]SmartTableParam param)
        {
            var result = await LectureService.Search(param);
            return Ok(result);
        }

        /// <summary>
        /// API lấy thông tin bài giảng theo Id
        /// </summary>
        /// <param name="id">Id bài giảng cần lấy</param>
        /// <returns></returns>
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = LectureService.GetById(id);
            return Ok(result);
        }

        [HttpPost("CreateOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate([FromBody]LectureModel model)
        {
            var result = await LectureService.CreateOrUpdate(model);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await LectureService.Delete(id);
            return Ok(result);
        }
    }
}
