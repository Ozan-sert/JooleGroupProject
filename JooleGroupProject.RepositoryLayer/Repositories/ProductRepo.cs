using JooleGroupProject.DAL.Interfaces;
using JooleGroupProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.RepositoryLayer.Repositories
{
    public class ProductRepo : GenericRepo<Product>, IProductRepo
    {
        public ProductRepo(MyDBContext _dbcontext) : base(_dbcontext)
        {

        }
    

        

        public IEnumerable<Product> GetProductsBySubCategory(int id)
        {
            return GetMany(x => x.SubCategoryID == id);
        }

        public IEnumerable<Product> GetProductsByModelYear(int year1, int year2)
        {
            return GetMany(x => x.ModelYear >= year1 && x.ModelYear <= year2);
        }

    }
}
