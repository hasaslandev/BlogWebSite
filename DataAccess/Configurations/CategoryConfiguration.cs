using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //builder.HasKey(x => x.CategoryID);
            //builder.Property(x => x.CategoryID).UseIdentityColumn();
            //builder.Property(x=>x.CategoryName).IsRequired().HasMaxLength(50);

            //builder.ToTable("Categories");

            //builder.HasOne(x=>x.Category).WithMany(x=>x.Blogs).HasForeignKey(x=>x.CategoryID);
            //builder.HasOne(x=>x.Category).WithOne(x=>x.Blogs).HasForeignKey<Blog>(x=>x.BlogId);
        }
    }
}
