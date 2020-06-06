using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PriSchLecs.Api.Domains.Categories;
using PriSchLecs.Api.Domains.Files;
using PriSchLecs.Api.Domains.Lectures;
using PriSchLecs.Api.Dtos.Items.Categories;
using PriSchLecs.Api.Dtos.Items.Files;
using PriSchLecs.Api.Dtos.Items.Lectures;
using PriSchLecs.Api.Dtos.Models.Categories;
using PriSchLecs.Api.Dtos.Models.Files;
using PriSchLecs.Api.Dtos.Models.Lectures;

namespace PriSchLecs.Api.Dtos
{
    public static class MappingExtension
    {
        public static MapperConfiguration MapperConfiguration;

        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return AutoMapperConfig.Mapper.Map<TSource, TDestination>(source);
        }
        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfig.Mapper.Map(source, destination);
        }

        #region Lecture
        public static LectureModel ToModel(this Lecture entity)
        {
            return entity.MapTo<Lecture, LectureModel>();
        }
        
        public static LectureItem ToItem(this Lecture entity)
        {
            return entity.MapTo<Lecture, LectureItem>();
        }
        
        public static Lecture ToLecture(this LectureModel model)
        {
            return model.MapTo<LectureModel, Lecture>();
        }

        public static Lecture ToLecture(this Lecture entity, Lecture destination)
        {
            return entity.MapTo(destination);
        }
        #endregion

        #region Comment
        public static CommentModel ToModel(this Comment entity)
        {
            return entity.MapTo<Comment, CommentModel>();
        }

        public static CommentItem ToItem(this Comment entity)
        {
            return entity.MapTo<Comment, CommentItem>();
        }

        public static Comment ToComment(this CommentModel model)
        {
            return model.MapTo<CommentModel, Comment>();
        }

        public static Comment ToComment(this Comment entity, Comment destination)
        {
            return entity.MapTo(destination);
        }
        #endregion

        #region Category
        public static CategoryModel ToModel(this Category entity)
        {
            return entity.MapTo<Category, CategoryModel>();
        }

        public static CategoryItem ToItem(this Category entity)
        {
            return entity.MapTo<Category, CategoryItem>();
        }

        public static Category ToCategory(this CategoryModel model)
        {
            return model.MapTo<CategoryModel, Category>();
        }

        public static Category ToCategory(this Category entity, Category destination)
        {
            return entity.MapTo(destination);
        }
        #endregion

        #region CategoryLecture
        public static CategoryLectureModel ToModel(this CategoryLecture entity)
        {
            return entity.MapTo<CategoryLecture, CategoryLectureModel>();
        }

        public static CategoryLectureItem ToItem(this CategoryLecture entity)
        {
            return entity.MapTo<CategoryLecture, CategoryLectureItem>();
        }

        public static CategoryLecture ToCategoryLecture(this CategoryLectureModel model)
        {
            return model.MapTo<CategoryLectureModel, CategoryLecture>();
        }

        public static CategoryLecture ToCategoryLecture(this CategoryLecture entity, CategoryLecture destination)
        {
            return entity.MapTo(destination);
        }
        #endregion

        #region Files
        public static FileModel ToModel(this File entity)
        {
            return entity.MapTo<File, FileModel>();
        }

        public static FileItem ToItem(this File entity)
        {
            return entity.MapTo<File, FileItem>();
        }

        public static File ToFile(this FileModel model)
        {
            return model.MapTo<FileModel, File>();
        }

        public static File ToFile(this File entity, File destination)
        {
            return entity.MapTo(destination);
        }
        #endregion

        #region LectureFile
        public static LectureFileModel ToModel(this LectureFile entity)
        {
            return entity.MapTo<LectureFile, LectureFileModel>();
        }

        public static LectureFileItem ToItem(this LectureFile entity)
        {
            return entity.MapTo<LectureFile, LectureFileItem>();
        }

        public static LectureFile ToLectureFile(this LectureFileModel model)
        {
            return model.MapTo<LectureFileModel, LectureFile>();
        }

        public static LectureFile ToLectureFile(this LectureFile entity, LectureFile destination)
        {
            return entity.MapTo(destination);
        }
        #endregion
    }
}
