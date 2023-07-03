using JooleGroupProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.RepositoryLayer
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("JooleEntities")
        { }

        public DbSet<DAL.Models.Attribute> Attributes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProductAttribute> AttributeValues { get; set; }
        public DbSet<TechSpecFilter> TechSpecFilters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
