using PriSchLecs.Api.Domains.Lectures;
using PriSchLecs.Api.Dtos;
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
    public interface ICommentService
    {
        Task<BaseResult> CreateOrUpdate(CommentModel model);
        Task<SmartTableResult<CommentItem>> Search(SmartTableParam param);
        CommentItem GetById(int id);
        Task<BaseResult> Delete(int id);
    }
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> CommentRepository;

        public CommentService(IRepository<Comment> commentRepository)
        {
            CommentRepository = commentRepository;
        }

        public async Task<BaseResult> CreateOrUpdate(CommentModel model)
        {
            var comment = model.ToComment();
            comment.UpdateCommonInt();

            var validParent = CommentRepository.Query().Where(x => x.LectureId == comment.LectureId).FirstOrDefault(x => x.Id == comment.ParentId);

            if(validParent == null)
            {
                return new CreateOrUpdateResult() { Result = Result.Failed, Message = "Không tìm thấy id bình luận cha trong danh sách bình luận của bài giảng" };
            }

            if (comment.Id > 0)
            {
                return await Update(comment);
            }
            else
            {
                return await Create(comment);
            }
        }

        private async Task<BaseResult> Create(Comment comment)
        {
            var result = new CreateOrUpdateResult();

            try
            {
                await CommentRepository.InsertAsync(comment);
            }
            catch (Exception e)
            {
                result.Result = Result.SystemError;
                result.Message = e.ToString();
                return result;
            }
            result.Id = comment.Id;
            return result;

        }

        private async Task<BaseResult> Update(Comment comment)
        {
            var result = new CreateOrUpdateResult();
            var commentForUpdate = CommentRepository.Query().FirstOrDefault(x => x.Id == comment.Id);

            if (commentForUpdate == null)
            {
                result.Result = Result.Failed;
                result.Message = "Không tìm thấy bình luận";
            }
            else
            {
                try
                {
                    commentForUpdate = comment.ToComment(commentForUpdate);
                    await CommentRepository.UpdateAsync(commentForUpdate);
                }
                catch (Exception e)
                {
                    result.Result = Result.SystemError;
                    result.Message = e.ToString();
                }
            }
            result.Id = commentForUpdate.Id;
            return result;
        }

        public async Task<BaseResult> Delete(int id)
        {
            var result = new BaseResult();
            var commentForDeletion = CommentRepository.Query().FirstOrDefault(x => x.Id == id);

            if (commentForDeletion == null)
            {
                result.Result = Result.Failed;
                result.Message = "Không tìm thấy bình luận";
            }
            else
            {
                try
                {
                   await CommentRepository.DeleteAsync(commentForDeletion);
                }
                catch(Exception e)
                {
                    result.Result = Result.SystemError;
                    result.Message = e.ToString();
                }
            }

            return result;
        }

        public CommentItem GetById(int id)
        {
            return id > 0 ? CommentRepository.GetById(id).ToItem() : new CommentItem();
        }

        public async Task<SmartTableResult<CommentItem>> Search(SmartTableParam param)
        {
            var query = CommentRepository.Query();
            if (param.Search.PredicateObject != null)
            {
                dynamic search = param.Search.PredicateObject;
                if (search.LectureId != null)
                {
                    int lectureId = search.LectureId;
                    query = query.Where(x => x.LectureId == lectureId);
                }
                if (search.ParentId != null)
                {
                    int parentId = search.ParentId;
                    query = query.Where(x => x.ParentId == parentId);
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
    }
}
