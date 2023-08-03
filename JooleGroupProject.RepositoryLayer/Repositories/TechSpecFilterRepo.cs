using JooleGroupProject.DAL.Interfaces;
using JooleGroupProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.RepositoryLayer.Repositories
{
    public class TechSpecFilterRepo : GenericRepo<TechSpecFilter>, ITechSpecFilterRepo
    {
        public TechSpecFilterRepo(MyDBContext _dbcontext) : base(_dbcontext)
        {

        }
    }
}
