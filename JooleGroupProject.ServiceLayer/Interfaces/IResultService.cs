using JooleGroupProject.DAL.Interfaces;
using JooleGroupProject.DAL.Models;
using JooleGroupProject.RepositoryLayer.Repositories;
using JooleGroupProject.ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.ServiceLayer.Interfaces
{
    public interface IResultService
    {
        IEnumerable<ProductDTO> GetProductsFilteredBySubCategory(int sub, int year1, int year2);
        List<ProductDTO> GetProductsBySubCategory(int subCategoryID);
        List<TechSpecFilterDTO> GetTechSpecFiltersForSubCategory(int sub);
        List<ProductAttributeDTO> GetIndividualProperties(int subid);

    }
}
