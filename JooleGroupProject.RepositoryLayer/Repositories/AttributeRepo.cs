using JooleGroupProject.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JooleGroupProject.DAL.Models;

namespace JooleGroupProject.RepositoryLayer.Repositories
{
    public class AttributeRepo : GenericRepo<JooleGroupProject.DAL.Models.Attribute>, IAttributeRepo
    {
        public AttributeRepo(MyDBContext _dbcontext) : base(_dbcontext)
        {

        }
        public JooleGroupProject.DAL.Models.Attribute GetAttribute(int id)
        {
            return this.GetByID(id);
        }

        public IEnumerable<JooleGroupProject.DAL.Models.Attribute> GetAttributes()
        {
            return this.GetAll();
        }
        
        public IEnumerable<JooleGroupProject.DAL.Models.Attribute> GetAttributesByTechSpec()
        {
            return this.GetMany(x => x.IsTechSpec == true);
        }
        public IEnumerable<JooleGroupProject.DAL.Models.Attribute> GetAttributesByType()
        {
            return this.GetMany(x => x.IsType == true);
        }
        
    }
}
