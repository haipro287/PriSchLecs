using Microsoft.AspNetCore.Mvc.TagHelpers;
using PriSchLecs.Api.Domains.Lectures;
using PriSchLecs.Api.Dtos;
using PriSchLecs.Api.Dtos.Items.Files;
using PriSchLecs.Api.Dtos.Items.Lectures;
using PriSchLecs.Api.Dtos.Models.Lectures;
using PriSchLecs.Api.Dtos.Results;
using PriSchLecs.Api.Infrastructure.SmartTable;
using PriSchLecs.Api.Infrastructures.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriSchLecs.Api.Infrastructures.Services.Lectures
{
    public interface ILectureFileService
    {
        Task<BaseResult> Create(LectureFileModel model);
        Task<BaseResult> Delete(int lectureId, int fileId);

        IQueryable<FileItem> GetFile(int lectureId);
        IQueryable<LectureItem> GetLecture(int fileId);
    }

    public class LectureFileService : ILectureFileService
    {
        private readonly IRepository<LectureFile> LectureFileRepository;

        public LectureFileService(IRepository<LectureFile> repository)
        {
            LectureFileRepository = repository;
        }

        public async Task<BaseResult> Create(LectureFileModel model)
        {
            var lectureFile = model.ToLectureFile();

            lectureFile.UpdateCommon();

            return await Create(lectureFile);
        }

        private async Task<BaseResult> Create(LectureFile lectureFile)
        {
            var result = new BaseResult();

            var exist = LectureFileRepository.QueryAll().FirstOrDefault(
                x => x.LectureId == lectureFile.LectureId
                && x.FileId == lectureFile.FileId);

            if (exist != null)
            {
                try
                {
                    exist.IsDeleted = false;
                    await LectureFileRepository.UpdateAsync(exist);
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
                    await LectureFileRepository.InsertAsync(lectureFile);
                }
                catch (Exception e)
                {
                    result.Result = Result.SystemError;
                    result.Message = e.ToString();
                }
            }
            return result;
        }

        public async Task<BaseResult> Delete(int lectureId, int fileId)
        {
            var result = new BaseResult();

            var instantForDeletion = LectureFileRepository.Query().FirstOrDefault(x =>
                x.FileId == fileId
                && x.LectureId == lectureId);

            if (instantForDeletion == null)
            {
                result.Result = Result.Failed;
                result.Message = "Không tìm thấy liên kết cần xóa";

            }
            else
            {
                try
                {
                    await LectureFileRepository.DeleteAsync(instantForDeletion);
                }
                catch (Exception e)
                {
                    result.Result = Result.SystemError;
                    result.Message = e.ToString();
                }
            }
            return result;
        }

        public IQueryable<FileItem> GetFile(int lectureId)
        {
            return LectureFileRepository.Query().Where(x => x.LectureId == lectureId).Select(x => x.File.ToItem());
        }

        public IQueryable<LectureItem> GetLecture(int fileId)
        {
            return LectureFileRepository.Query().Where(x => x.FileId == fileId).Select(x => x.Lecture.ToItem());
        }
    }
}
