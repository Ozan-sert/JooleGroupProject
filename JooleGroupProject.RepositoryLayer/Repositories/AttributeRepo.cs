using JooleGroupProject.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JooleGroupProject.DAL.Models;
using Attribute = JooleGroupProject.DAL.Models.Attribute;

namespace JooleGroupProject.RepositoryLayer.Repositories
{
    public class AttributeRepo : GenericRepo<Attribute>, IAttributeRepo
    {
        public AttributeRepo(MyDBContext _dbcontext) : base(_dbcontext)
        {

        }
        public Attribute GetAttribute(int id)
        {
            return this.GetByID(id);
        }

        public IEnumerable<Attribute> GetAttributes()
        {
            return this.GetAll();
        }
        
        public IEnumerable<Attribute> GetAttributesByTechSpec()
        {
            return this.GetMany(x => x.IsTechSpec == true);
        }
        public IEnumerable<Attribute> GetAttributesByType()
        {
            return this.GetMany(x => x.IsType == true);
        }
        
    }
}
