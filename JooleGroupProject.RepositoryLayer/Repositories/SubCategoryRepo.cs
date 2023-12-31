﻿using JooleGroupProject.DAL.Interfaces;
using JooleGroupProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.RepositoryLayer.Repositories
{
    public class SubCategoryRepo : GenericRepo<SubCategory>, ISubCategoryRepo
    {
        public SubCategoryRepo(MyDBContext _dbcontext) : base(_dbcontext)
        {

        }

        public IEnumerable<SubCategory> GetSubCategoriesByCategory(int id)
        {
            return GetMany(x => x.CategoryID == id);
        }

        public SubCategory GetSubCategoryByName(string name)
        {
            return Get(x => x.SubCategoryName.Equals(name)); 
        }
    }
}
