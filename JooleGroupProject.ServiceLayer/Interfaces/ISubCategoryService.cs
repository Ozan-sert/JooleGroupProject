using JooleGroupProject.DAL.Models;
using JooleGroupProject.RepositoryLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.ServiceLayer.Interfaces
{
    public interface ISubCategoryService
    {
        List<SubCategory> GetSubsforCategory(int id);
    }
}
