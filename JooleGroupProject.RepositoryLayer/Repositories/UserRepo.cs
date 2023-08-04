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

        public User GetUserByID(int id) { 
            return this.GetByID(id); 
        }

        // when login ==> get the password
        public User GetUserByName(string name) {
            return this.Get(x => x.UserName == name); 
        }

        public void AddUser(User user) {
            this.Insert(user); 
        } 
    }
}
