using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriSchLecs.Api.Domains.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriSchLecs.Api.Infrastructures.Data.EntityMapping.Files
{
    public class FIleMap : IEntityMappingConfiguration<File>
    {
        public void Map(EntityTypeBuilder<File> builder)
        {
            builder.ToTable("File");
        }
    }
}
