using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PriSchLecs.Api.Infrastructures.Data
{
    public class PriSchLecsDbContext: DbContext
    {
        public PriSchLecsDbContext(DbContextOptions<PriSchLecsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }
    }
}
