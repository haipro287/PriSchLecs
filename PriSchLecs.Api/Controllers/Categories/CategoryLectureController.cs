using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PriSchLecs.Api.Dtos.Items.Categories;
using PriSchLecs.Api.Dtos.Models.Categories;
using PriSchLecs.Api.Infrastructure.SmartTable;
using PriSchLecs.Api.Infrastructures.Services.Categories;

namespace PriSchLecs.Api.Controllers.Categories
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryLectureController: ControllerBase
    {
        private readonly ICategoryLectureService CategoryLectureService;

        public CategoryLectureController(ICategoryLectureService categoryLectureService)
        {
            CategoryLectureService = categoryLectureService;
        }

        /// <summary>
        /// API Tạo liên kết danh mục - bài giảng
        /// </summary>
        /// <param name="model">Model liên kết</param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]CategoryLectureModel model)
        {
            var result = await CategoryLectureService.Create(model);
            return Ok(result);
        }

        /// <summary>
        /// API xóa liên kết danh mục - bài giảng
        /// </summary>
        /// <param name="categoryId">Id của danh mục</param>
        /// <param name="lectureId">Id của bài giảng</param>
        /// <returns></returns>
        [HttpDelete("Delete/{categoryId}-{lectureId}")]
        public async Task<IActionResult> Delete(int categoryId, int lectureId)
        {
            var result = await CategoryLectureService.Delete(categoryId, lectureId);
            return Ok(result);
        }

        /// <summary>
        /// API lấy danh mục theo Id bài giảng
        /// </summary>
        /// <param name="lectureId">Id bài giảng</param>
        /// <returns></returns>
        [HttpGet("GetCategoryByLectureId/{lectureId}")]
        public async Task<IActionResult> GetCategoryByLectureId(int lectureId)
        {
            var result = CategoryLectureService.GetCategory(lectureId);
            return Ok(result);
        }

        /// <summary>
        /// API lấy bài giảng theo Id danh mục
        /// </summary>
        /// <param name="param">Tham số SmartTable tìm kiếm theo Id danh mục (CategoryId), phân trang, sắp xếp</param>
        /// <returns></returns>
       [HttpPost("GetLectureByCategoryId/")]
       public async Task<IActionResult> GetLectureByCategoryId([FromBody] SmartTableParam param)
        {
            var result = await CategoryLectureService.GetLecture(param);
            return Ok(result);
        }
    }
}
