using IrmsManagement.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IrmsManagement.Data
{
    public class IrmsManagementDbContext : DbContext
    {
        public IrmsManagementDbContext(DbContextOptions<IrmsManagementDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ContactConfiguration());
        }
    }
}
