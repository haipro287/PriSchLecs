using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriSchLecs.Api.Domains.Lectures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriSchLecs.Api.Infrastructures.Data.EntityMapping.Lectures
{
    public class CommentMap : IEntityMappingConfiguration<Comment>
    {
        public void Map(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(x => x.Parent).WithMany().HasForeignKey(x => x.ParentId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Lecture).WithMany().HasForeignKey(x => x.LectureId).OnDelete(DeleteBehavior.NoAction);
            builder.ToTable("Comment");
        }
    }
}
