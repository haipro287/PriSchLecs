using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PriSchLecs.Api.Infrastructures.Data.EntityMapping
{
    public interface IEntityMappingConfiguration<T> where  T: class
    {
        void Map(EntityTypeBuilder<T> builder);
    }
}
