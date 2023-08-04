using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.DAL.Interfaces
{
    public interface IAttributeRepo 
    {
        JooleGroupProject.DAL.Models.Attribute GetAttribute(int id);
        IEnumerable<JooleGroupProject.DAL.Models.Attribute> GetAttributes();
        IEnumerable<JooleGroupProject.DAL.Models.Attribute> GetAttributesByTechSpec();
        IEnumerable<JooleGroupProject.DAL.Models.Attribute> GetAttributesByType();
    }
}
