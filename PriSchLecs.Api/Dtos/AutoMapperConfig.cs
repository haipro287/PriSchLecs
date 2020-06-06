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
    public class AutoMapperConfig
    {
        #region Properties
        private static MapperConfiguration _mapperConfiguration;
        private static IMapper _mapper;

        /// <summary>
        /// Mapper
        /// </summary>
        public static IMapper Mapper => _mapper;

        /// <summary>
        /// Mapper configuration
        /// </summary>
        public static MapperConfiguration MapperConfiguration => _mapperConfiguration;
        #endregion

        public static void Init()
        {
            try
            {
                _mapperConfiguration = new MapperConfiguration(cfg =>
                {
                    #region Lecture
                    cfg.CreateMap<Lecture, Lecture>()
                        .ForMember(dest => dest.Id, opt => opt.Ignore())
                        .ForMember(dest => dest.CreatedTime, opt => opt.Ignore())
                        .ForMember(dest => dest.UpdatedTime, opt => opt.Ignore());
                    cfg.CreateMap<Lecture, LectureModel>();
                    cfg.CreateMap<Lecture, LectureItem>();
                    cfg.CreateMap<LectureModel, Lecture>();
                    #endregion

                    #region Comment
                    cfg.CreateMap<Comment, Comment>()
                        .ForMember(dest => dest.Id, opt => opt.Ignore())
                        .ForMember(dest => dest.CreatedTime, opt => opt.Ignore())
                        .ForMember(dest => dest.UpdatedTime, opt => opt.Ignore());
                    cfg.CreateMap<Comment, CommentModel>();
                    cfg.CreateMap<Comment, CommentItem>();
                    cfg.CreateMap<CommentModel, Comment>();
                    #endregion

                    #region Category
                    cfg.CreateMap<Category, Category>()
                        .ForMember(dest => dest.Id, opt => opt.Ignore())
                        .ForMember(dest => dest.CreatedTime, opt => opt.Ignore())
                        .ForMember(dest => dest.UpdatedTime, opt => opt.Ignore());
                    cfg.CreateMap<Category, CategoryModel>();
                    cfg.CreateMap<Category, CategoryItem>();
                    cfg.CreateMap<CategoryModel, Category>();
                    #endregion

                    #region CategoryLecture
                    cfg.CreateMap<CategoryLecture, CategoryLecture>()
                        .ForMember(dest => dest.CreatedTime, opt => opt.Ignore())
                        .ForMember(dest => dest.UpdatedTime, opt => opt.Ignore());
                    cfg.CreateMap<CategoryLecture, CategoryLectureModel>();
                    cfg.CreateMap<CategoryLecture, CategoryLectureItem>();
                    cfg.CreateMap<CategoryLectureModel, CategoryLecture>();
                    #endregion

                    #region Files
                    cfg.CreateMap<File, File>()
                        .ForMember(dest => dest.Id, opt => opt.Ignore())
                        .ForMember(dest => dest.CreatedTime, opt => opt.Ignore())
                        .ForMember(dest => dest.UpdatedTime, opt => opt.Ignore());
                    cfg.CreateMap<File, FileModel>();
                    cfg.CreateMap<File, FileItem>();
                    cfg.CreateMap<FileModel, File>();
                    #endregion

                    #region lectureFile
                    cfg.CreateMap<LectureFile, LectureFile>()
                        .ForMember(dest => dest.CreatedTime, opt => opt.Ignore())
                        .ForMember(dest => dest.UpdatedTime, opt => opt.Ignore());
                    cfg.CreateMap<LectureFile, LectureFileModel>();
                    cfg.CreateMap<LectureFile, LectureFileItem>();
                    cfg.CreateMap<LectureFileModel, LectureFile>();
                    #endregion
                });

                _mapper = _mapperConfiguration.CreateMapper();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
