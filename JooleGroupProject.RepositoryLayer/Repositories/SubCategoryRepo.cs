using JooleGroupProject.DAL.Interfaces;
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
    }
}
