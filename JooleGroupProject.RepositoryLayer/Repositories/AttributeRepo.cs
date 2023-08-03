using JooleGroupProject.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.RepositoryLayer.Repositories
{
    public class AttributeRepo : GenericRepo<Attribute>, IAttributeRepo
    {
        public AttributeRepo(MyDBContext _dbcontext) : base(_dbcontext)
        {

        }
    }
}
