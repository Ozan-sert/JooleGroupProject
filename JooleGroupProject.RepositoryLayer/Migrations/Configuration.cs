namespace JooleGroupProject.RepositoryLayer.Migrations
{
    using JooleGroupProject.DAL.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JooleGroupProject.RepositoryLayer.MyDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(JooleGroupProject.RepositoryLayer.MyDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var categories = new List<Category>
            {
                new Category { CategoryID = 1, CategoryName = "Mechanical" },
                new Category { CategoryID = 2, CategoryName = "Electrical" },
                new Category { CategoryID = 3, CategoryName = "Stationary" },
                new Category { CategoryID = 4, CategoryName = "Furniture" },
            };

            foreach (var category in categories)
            {
                context.Categories.AddOrUpdate(c => c.CategoryID, category);
            }

            context.SaveChanges();
        }
    }
}
