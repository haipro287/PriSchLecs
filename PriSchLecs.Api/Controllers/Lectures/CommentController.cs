using Microsoft.AspNetCore.Mvc;
using PriSchLecs.Api.Dtos.Models.Lectures;
using PriSchLecs.Api.Infrastructure.SmartTable;
using PriSchLecs.Api.Infrastructures.Services.Lectures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriSchLecs.Api.Controllers.Lectures
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController: ControllerBase
    {
        private readonly ICommentService CommentService;

        public CommentController(ICommentService commentService)
        {
            CommentService = commentService;
        }

        /// <summary>
        /// API tìm kiếm bình luận
        /// </summary>
        /// <param name="param">Tham số SmartTable (tìm kiếm theo tên Mã bài giảng (LectureId), theo mã cha (ParentId), phân trang, sắp xếp)</param>
        /// <returns></returns>
        [HttpPost("Search")]
        public async Task<IActionResult> Search([FromBody]SmartTableParam param)
        {
            var result = await CommentService.Search(param);
            return Ok(result);
        }

        /// <summary>
        /// API lấy thông tin bình luận theo Id
        /// </summary>
        /// <param name="id">Id bình luận cần lấy</param>
        /// <returns></returns>
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = CommentService.GetById(id);
            return Ok(result);
        }

        /// <summary>
        /// API tạo mới hoặc cập nhật bình luận
        /// </summary>
        /// <param name="model">Model muốn tạo mới hoặc cập nhật</param>
        /// <returns></returns>
        [HttpPost("CreateOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate([FromBody]CommentModel model)
        {
            var result = await CommentService.CreateOrUpdate(model);
            return Ok(result);
        }

        /// <summary>
        /// API xóa bình luận theo Id
        /// </summary>
        /// <param name="id">Id bình luận cần xóa</param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await CommentService.Delete(id);
            return Ok(result);
        }

    }
}
