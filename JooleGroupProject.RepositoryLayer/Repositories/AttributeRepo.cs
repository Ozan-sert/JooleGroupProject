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
      

       
        
        public IEnumerable<Attribute> GetAttributesByTechSpec() => GetMany(x => x.IsTechSpec == true);
        public IEnumerable<Attribute> GetAttributesByType() => GetMany(x =>x.IsType == true);

    }
}
