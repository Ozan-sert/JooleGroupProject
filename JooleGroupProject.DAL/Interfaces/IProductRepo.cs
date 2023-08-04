using JooleGroupProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.DAL.Interfaces
{
    public interface IProductRepo : IGenericRepo<Product> 
    {
        Product GetProduct(int id);

        IEnumerable<Product> GetProductsBySubCategory(int id);

        //public IEnumerable<Product> GetProducts()


        IEnumerable<Product> GetProductsByModelYear(int year1, int year2);

    }
}
