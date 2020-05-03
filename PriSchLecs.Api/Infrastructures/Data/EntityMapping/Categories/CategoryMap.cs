using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PriSchLecs.Api.Domains.Categories;

namespace PriSchLecs.Api.Infrastructures.Data.EntityMapping.Categories
{
    public class CategoryMap : IEntityMappingConfiguration<Category>
    {
        public void Map(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(c => c.Children).WithOne(c => c.Parent).HasForeignKey(c => c.ParentId).OnDelete(DeleteBehavior.NoAction);
            builder.ToTable("Category");
        }
    }
}
