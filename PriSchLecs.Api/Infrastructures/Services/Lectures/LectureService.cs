using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PriSchLecs.Api.Domains.Lectures;
using PriSchLecs.Api.Dtos;
using PriSchLecs.Api.Dtos.Items.Lectures;
using PriSchLecs.Api.Dtos.Models.Lectures;
using PriSchLecs.Api.Dtos.Results;
using PriSchLecs.Api.Infrastructure.SmartTable;
using PriSchLecs.Api.Infrastructures.Repositories;

namespace PriSchLecs.Api.Infrastructures.Services.Lectures
{
    public interface ILectureService
    {
        Task<SmartTableResult<LectureItem>> Search(SmartTableParam param);
        LectureItem GetById(int id);
        Task<BaseResult> CreateOrUpdate(LectureModel model);
        Task<BaseResult> Delete(int id);
    }

    public class LectureService : ILectureService
    {
        private readonly IRepository<Lecture> LectureRepository;

        public LectureService(IRepository<Lecture> lectureRepository)
        {
            LectureRepository = lectureRepository;
        }

        public async Task<BaseResult> CreateOrUpdate(LectureModel model)
        {
            var lecture = model.ToLecture();

            lecture = lecture.UpdateCommonInt();

            if (lecture.Id > 0)
            {
                return await Update(lecture);
            }
            else
            {
                return await Create(lecture);
            }
        }

        public async Task<BaseResult> Delete(int id)
        {
            var result = new BaseResult() { Result = Result.Success };
            var lectureForDeletion = LectureRepository.GetById(id);
            if (lectureForDeletion == null)
            {
                result.Result = Result.Failed;
                result.Message = "Không tìm thấy bài giảng yêu cầu";
                return result;
            }

            try
            {
                await LectureRepository.DeleteAsync(lectureForDeletion);
            }
            catch (Exception e)
            {
                result.Result = Result.SystemError;
                result.Message = e.ToString();
            }
            return result;

        }

        public LectureItem GetById(int id)
        {
            return id > 0 ? LectureRepository.GetById(id).ToItem() : new LectureItem();
        }

        public async Task<SmartTableResult<LectureItem>> Search(SmartTableParam param)
        {
            var query = LectureRepository.Query();
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

        private async Task<BaseResult> Create(Lecture lecture)
        {
            var result = new CreateOrUpdateResult() { Result = Result.Success };
            lecture.Name = lecture.Name.Trim();
            try
            {
                await LectureRepository.InsertAsync(lecture);
            }
            catch(Exception e)
            {
                result.Result = Result.SystemError;
                result.Message = e.ToString();
                return result;
            }
            result.Id = lecture.Id;
            return result;
        }

        private async Task<BaseResult> Update(Lecture lecture)
        {
            var result = new CreateOrUpdateResult() { Result = Result.Success };
            var lectureForUpdate = LectureRepository.Query().FirstOrDefault(l => l.Id == lecture.Id);
            if (lectureForUpdate == null)
            {
                result.Result = Result.Failed;
                result.Message = "Không tìm thấy bài giảng";
                return result;
            }
            try
            {
                lectureForUpdate = lecture.ToLecture(lectureForUpdate);
                lectureForUpdate = lectureForUpdate.UpdateCommonInt();

                await LectureRepository.UpdateAsync(lectureForUpdate);
            }
            catch(Exception e)
            {
                result.Result = Result.SystemError;
                result.Message = e.ToString();
            }
            result.Id = lectureForUpdate.Id;
            return result;
        }
    }
}
