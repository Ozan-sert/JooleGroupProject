using JooleGroupProject.DAL.Interfaces;
using JooleGroupProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.RepositoryLayer.Repositories
{
    public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
    {
        public CategoryRepo(MyDBContext _dbcontext) : base(_dbcontext)
        {

        }

        public IEnumerable<Category> GetCategories() {
            return GetAll(); 
        } 
            
        public Category GetCategory(int id)
        {
            return GetByID(id);
        }
    }
}
