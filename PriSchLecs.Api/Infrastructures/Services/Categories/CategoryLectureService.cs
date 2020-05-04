using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PriSchLecs.Api.Domains.Categories;
using PriSchLecs.Api.Dtos;
using PriSchLecs.Api.Dtos.Items.Categories;
using PriSchLecs.Api.Dtos.Items.Lectures;
using PriSchLecs.Api.Dtos.Models.Categories;
using PriSchLecs.Api.Dtos.Results;
using PriSchLecs.Api.Infrastructure.SmartTable;
using PriSchLecs.Api.Infrastructures.Repositories;

namespace PriSchLecs.Api.Infrastructures.Services.Categories
{
    public interface ICategoryLectureService
    {
        Task<BaseResult> Create(CategoryLectureModel model);
        Task<BaseResult> Delete(int categoryId, int lectureId);

        Task<SmartTableResult<LectureItem>> GetLecture(SmartTableParam param);
        IQueryable<CategoryItem> GetCategory(int lectureId);
    }
    public class CategoryLectureService : ICategoryLectureService
    {
        private readonly IRepository<CategoryLecture> CategoryLectureRepository;

        public CategoryLectureService(IRepository<CategoryLecture> categoryLectureRepository)
        {
            CategoryLectureRepository = categoryLectureRepository;
        }

        public async Task<BaseResult> Create(CategoryLectureModel model)
        {
            var categoryLecture = model.ToCategoryLecture();

            categoryLecture.UpdateCommon();

            return await Create(categoryLecture);
        }

        private async Task<BaseResult> Create(CategoryLecture categoryLecture)
        {
            var result = new BaseResult();

            var exist = CategoryLectureRepository.QueryAll().FirstOrDefault(
                x => x.CategoryId == categoryLecture.CategoryId
                && x.LectureId == categoryLecture.LectureId);

            if (exist != null)
            {
                try
                {
                    exist.IsDeleted = false;
                    await CategoryLectureRepository.UpdateAsync(exist);
                }
                catch (Exception e)
                {
                    result.Result = Result.SystemError;
                    result.Message = e.ToString();
                }
            }
            else
            {
                try
                {
                    await CategoryLectureRepository.InsertAsync(categoryLecture);
                }
                catch (Exception e)
                {
                    result.Result = Result.SystemError;
                    result.Message = e.ToString();
                }
            }
            return result;
        }

        public async Task<BaseResult> Delete(int categoryId, int LectureId)
        {
            var result = new BaseResult();

            var instantForDeletion = CategoryLectureRepository.Query().FirstOrDefault(x =>
                x.CategoryId == categoryId
                && x.LectureId == LectureId);

            if (instantForDeletion == null)
            {
                result.Result = Result.Failed;
                result.Message = "Không tìm thấy liên kết cần xóa";

            }
            else
            {
                try
                {
                    await CategoryLectureRepository.DeleteAsync(instantForDeletion);
                }
                catch(Exception e)
                {
                    result.Result = Result.SystemError;
                    result.Message = e.ToString();
                }
            }
            return result;
        }

        public async Task<SmartTableResult<LectureItem>> GetLecture(SmartTableParam param)
        {
            var query = CategoryLectureRepository.Query();
            IQueryable<LectureItem> result = null;
            if (param.Search.PredicateObject != null)
            {
                dynamic search = param.Search.PredicateObject;
                if (search.CategoryId != null)
                {
                    int categoryId = search.CategoryId;
                    result = query.Where(x => x.CategoryId == categoryId).Select(x => x.Lecture.ToItem());
                }
                if (search.CreateStart != null)
                {
                    DateTime createStart = DateTime.Parse(search.CreateStart.ToString());
                    DateTime startOfDay = createStart.Date;
                    result = result.Where(x => x.CreatedTime >= startOfDay);
                }

                if (search.CreateEnd != null)
                {
                    DateTime createEnd = DateTime.Parse(search.CreateEnd.ToString());
                    DateTime endOfDay = createEnd.Date.AddDays(1).AddTicks(-1);
                    result = result.Where(x => x.CreatedTime <= endOfDay);
                }
            }
            var gridData = result.ToSmartTableResult(param, x => x);
            return gridData;
        }

        public IQueryable<CategoryItem> GetCategory(int lectureId)
        {
            return CategoryLectureRepository.Query().Where(x => x.LectureId == lectureId).Select(x => x.Category.ToItem());
        }
    }
}
