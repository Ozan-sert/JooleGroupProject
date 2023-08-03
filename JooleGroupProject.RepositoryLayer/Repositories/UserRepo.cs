using JooleGroupProject.DAL.Models;
using JooleGroupProject.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.RepositoryLayer.Repositories
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        public UserRepo(MyDBContext _dbcontext) : base(_dbcontext)
        {

        }
    }
}
