using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attribute = JooleGroupProject.DAL.Models.Attribute;

namespace JooleGroupProject.DAL.Interfaces
{
    public interface IAttributeRepo 
    {
        Attribute GetAttribute(int id);
        IEnumerable<Attribute> GetAttributes();
        IEnumerable<Attribute> GetAttributesByTechSpec();
        IEnumerable<Attribute> GetAttributesByType();
    }
}
