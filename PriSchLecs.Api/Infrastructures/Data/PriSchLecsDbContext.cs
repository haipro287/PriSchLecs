using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PriSchLecs.Api.Domains.Categories;
using PriSchLecs.Api.Domains.Files;
using PriSchLecs.Api.Domains.Lectures;
using PriSchLecs.Api.Infrastructures.Data.EntityMapping;
using PriSchLecs.Api.Infrastructures.Data.EntityMapping.Categories;
using PriSchLecs.Api.Infrastructures.Data.EntityMapping.Files;
using PriSchLecs.Api.Infrastructures.Data.EntityMapping.Lectures;

namespace PriSchLecs.Api.Infrastructures.Data
{
    public class PriSchLecsDbContext : DbContext
    {
        public PriSchLecsDbContext(DbContextOptions<PriSchLecsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder
                .RegisterEntityMapping<Lecture, LectureMap>()
                .RegisterEntityMapping<Comment, CommentMap>()
                .RegisterEntityMapping<Category, CategoryMap>()
                .RegisterEntityMapping<CategoryLecture, CategoryLectureMap>()
                .RegisterEntityMapping<File, FIleMap>()
                .RegisterEntityMapping<LectureFile, LectureFileMap>();
        }
    }
}
