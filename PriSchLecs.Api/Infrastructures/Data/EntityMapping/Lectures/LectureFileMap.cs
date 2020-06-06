using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriSchLecs.Api.Domains.Lectures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriSchLecs.Api.Infrastructures.Data.EntityMapping.Lectures
{
    public class LectureFileMap : IEntityMappingConfiguration<LectureFile>
    {
        public void Map(EntityTypeBuilder<LectureFile> builder)
        {
            builder.HasOne(x => x.Lecture).WithMany().HasForeignKey(x => x.LectureId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.File).WithMany().HasForeignKey(x => x.FileId).OnDelete(DeleteBehavior.NoAction);
            builder.HasKey(x => new { x.LectureId, x.FileId });
            builder.ToTable("LectureFile");
        }
    }
}
