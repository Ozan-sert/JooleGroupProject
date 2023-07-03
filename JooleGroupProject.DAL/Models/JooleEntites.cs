using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.DAL.Models
{
    public class JooleEntites : DbContext
    {
        public JooleEntites() : base("name=JooleEntities")
        { }

        public virtual DbSet<Attribute> Attributes { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<AttributeValue> AttributeValues { get; set; }
        public virtual DbSet<TechSpecFilter> TechSpecFilters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        
    }
}

