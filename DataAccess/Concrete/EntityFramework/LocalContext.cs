using CoreL.Entities.Concrete;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class LocalContext : DbContext
    {
        //public LocalContext(DbContextOptions<LocalContext> options):base(options)
        //{ 
        //    var p = new Admin() {Blog= new Blog() { } }
        //}


        public DbSet<About> Abouts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SubscribeMail> subscribeMails { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<AdminOperationClaim> AdminOperationClaims { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-M89OB8P;Database=BlogSimpleDb;Trusted_Connection=true");
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//Hepsine Uygula diyoruz
        //    modelBuilder.ApplyConfiguration(new BlogConfiguration());//Tek tekte yapabiliriz
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
