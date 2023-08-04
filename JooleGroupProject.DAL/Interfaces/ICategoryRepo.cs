using JooleGroupProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.DAL.Interfaces
{
    public interface ICategoryRepo 
    {
        IEnumerable<Category> GetCategories();

        Category GetCategory(int id); 
    }
}
