using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PriSchLecs.Api.Dtos.Models.Categories;
using PriSchLecs.Api.Infrastructure.SmartTable;
using PriSchLecs.Api.Infrastructures.Services.Categories;

namespace PriSchLecs.Api.Controllers.Categories
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController: ControllerBase
    {
        private readonly ICategoryService CategoryService;

        public CategoryController(ICategoryService categoryService)
        {
            CategoryService = categoryService;
        }

        /// <summary>
        /// API tìm kiếm danh mục
        /// </summary>
        /// <param name="param">Tham số SmartTable (tìm kiếm theo tên (Keyword), theo danh mục cha (ParentId), phân trang, sắp xếp)</param>
        /// <returns></returns>
        [HttpPost("Search")]
        public async Task<IActionResult> Search([FromBody]SmartTableParam param)
        {
            var result = await CategoryService.Search(param);
            return Ok(result);
        }

        /// <summary>
        /// API lấy thông tin danh mục theo Id
        /// </summary>
        /// <param name="id">Id danh mục cần lấy</param>
        /// <returns></returns>
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = CategoryService.GetById(id);
            return Ok(result);
        }

        /// <summary>
        /// API tạo mới hoặc cập nhật danh mục
        /// </summary>
        /// <param name="model">Model muốn tạo mới hoặc cập nhật</param>
        /// <returns></returns>
        [HttpPost("CreateOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate([FromBody]CategoryModel model)
        {
            var result = await CategoryService.CreateOrUpdate(model);
            return Ok(result);
        }

        /// <summary>
        /// API xóa danh mục theo Id
        /// </summary>
        /// <param name="id">Id cần xóa</param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await CategoryService.Delete(id);
            return Ok(result);
        }
    }
}
