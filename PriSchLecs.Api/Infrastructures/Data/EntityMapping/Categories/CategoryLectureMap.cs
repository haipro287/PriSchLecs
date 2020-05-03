using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriSchLecs.Api.Domains.Categories;

namespace PriSchLecs.Api.Infrastructures.Data.EntityMapping.Categories
{
    public class CategoryLectureMap : IEntityMappingConfiguration<CategoryLecture>
    {
        public void Map(EntityTypeBuilder<CategoryLecture> builder)
        {
            builder.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Lecture).WithMany().HasForeignKey(x => x.LectureId).OnDelete(DeleteBehavior.NoAction);
            builder.HasKey(x => new { x.CategoryId, x.LectureId });
            builder.ToTable("CategoryLecture");
        }
    }
}
