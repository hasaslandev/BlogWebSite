using CoreL.Entities;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Seeds
{
    internal class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //builder.HasData(
            //    new Category { CategoryID = 1, CategoryName = "Kalemler" },
            //    new Category{ CategoryID = 2, CategoryName = "Kitaplar" });
        }
    }
}
