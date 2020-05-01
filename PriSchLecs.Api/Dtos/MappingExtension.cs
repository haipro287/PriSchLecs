using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PriSchLecs.Api.Domains.Categories;
using PriSchLecs.Api.Domains.Lectures;
using PriSchLecs.Api.Dtos.Items.Categories;
using PriSchLecs.Api.Dtos.Items.Lectures;
using PriSchLecs.Api.Dtos.Models.Categories;
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
    }
}
