using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PriSchLecs.Api.Domains.Categories;
using PriSchLecs.Api.Dtos;
using PriSchLecs.Api.Dtos.Items.Categories;
using PriSchLecs.Api.Dtos.Models.Categories;
using PriSchLecs.Api.Dtos.Results;
using PriSchLecs.Api.Infrastructure.SmartTable;
using PriSchLecs.Api.Infrastructures.Repositories;

namespace PriSchLecs.Api.Infrastructures.Services.Categories
{
    public interface ICategoryService
    {
        Task<SmartTableResult<CategoryItem>> Search(SmartTableParam param);
        CategoryItem GetById(int id);
        Task<BaseResult> CreateOrUpdate(CategoryModel model);
        Task<BaseResult> Delete(int id);
    }

    public class CategoryService: ICategoryService
    {
        private readonly IRepository<Category> CategoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }

        public Task<BaseResult> CreateOrUpdate(CategoryModel model)
        {
            var category = model.ToCategory();

            if(category.Id > 0)
            {
                return Update(category);
            }
            else
            {
                return Create(category);
            }
        }

        public async Task<BaseResult> Delete(int id)
        {
            var result = new BaseResult() { Result = Result.Success };
            var categoryForDeletion = CategoryRepository.GetById(id);
            if (categoryForDeletion == null)
            {
                result.Result = Result.Failed;
                result.Message = "Không tìm thấy bài giảng yêu cầu";
                return result;
            }

            try
            {
                await CategoryRepository.DeleteAsync(categoryForDeletion);
            }
            catch (Exception e)
            {
                result.Result = Result.SystemError;
                result.Message = e.ToString();
            }
            return result;
        }

        public CategoryItem GetById(int id)
        {
            return id > 0 ? CategoryRepository.GetById(id).ToItem() : new CategoryItem(); 
        }

        public async Task<SmartTableResult<CategoryItem>> Search(SmartTableParam param)
        {
            var query = CategoryRepository.Query();
            if (param.Search.PredicateObject != null)
            {
                dynamic search = param.Search.PredicateObject;
                if (search.Keyword != null)
                {
                    string keyword = search.Keyword;
                    keyword = keyword.Trim().ToLower();
                    query = query.Where(x => x.Name.Contains(keyword));
                }
                if (search.CreateStart != null)
                {
                    DateTime createStart = DateTime.Parse(search.CreateStart.ToString());
                    DateTime startOfDay = createStart.Date;
                    query = query.Where(x => x.CreatedTime >= startOfDay);
                }

                if (search.CreateEnd != null)
                {
                    DateTime createEnd = DateTime.Parse(search.CreateEnd.ToString());
                    DateTime endOfDay = createEnd.Date.AddDays(1).AddTicks(-1);
                    query = query.Where(x => x.CreatedTime <= endOfDay);
                }
            }

            //param.Sort = new Sort() { Predicate = "Id", Reverse = false };
            var gridData = query.ToSmartTableResult(param, x => x.ToItem());
            return gridData;
        }

        private async Task<BaseResult> Create(Category category)
        {
            var result = new CreateOrUpdateResult() { Result = Result.Success };
            category.Name = category.Name.Trim();
            try
            {
                await CategoryRepository.InsertAsync(category);
            }
            catch (Exception e)
            {
                result.Result = Result.SystemError;
                result.Message = e.ToString();
                return result;
            }
            result.Id = category.Id;
            return result;
        }

        private async Task<BaseResult> Update(Category category)
        {
            var result = new CreateOrUpdateResult() { Result = Result.Success };
            var categoryForUpdation = CategoryRepository.Query().FirstOrDefault(l => l.Id == category.Id);
            if (categoryForUpdation == null)
            {
                result.Result = Result.Failed;
                result.Message = "Không tìm thấy danh mục";
                return result;
            }
            try
            {
                categoryForUpdation = category.ToCategory(categoryForUpdation);
                categoryForUpdation = categoryForUpdation.UpdateCommonInt();

                await CategoryRepository.UpdateAsync(categoryForUpdation);
            }
            catch (Exception e)
            {
                result.Result = Result.SystemError;
                result.Message = e.ToString();
            }
            result.Id = categoryForUpdation.Id;
            return result;
        }
    }
}
