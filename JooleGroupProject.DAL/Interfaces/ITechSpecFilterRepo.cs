using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JooleGroupProject.DAL.Models;

namespace JooleGroupProject.DAL.Interfaces
{
    public interface ITechSpecFilterRepo : IGenericRepo<TechSpecFilter>
    {
        List<TechSpecFilter> GetGeneralTechSpecAttributesBySubCategory(int sub);
    }
}
