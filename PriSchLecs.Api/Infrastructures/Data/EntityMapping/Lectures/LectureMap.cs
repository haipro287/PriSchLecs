using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriSchLecs.Api.Domains.Lectures;

namespace PriSchLecs.Api.Infrastructures.Data.EntityMapping.Lectures
{
    public class LectureMap: IEntityMappingConfiguration<Lecture>
    {
        public void Map(EntityTypeBuilder<Lecture> builder)
        {
            builder.ToTable("Lecture");
        }
    }
}
