using JooleGroupProject.DAL.Models;
using JooleGroupProject.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace JooleGroupProject.RepositoryLayer.Repositories
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        public UserRepo(MyDBContext _dbcontext) : base(_dbcontext)
        {

        }


        // when login ==> get the password
        public User GetUserByName(string name) {
            return Get(x => x.UserName == name); 
        }

        public User GetUserByEmail(string email) {
            return Get(x => x.EmailAddress == email); 
        }

        public void AddUser(User user) {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null.");
            }

            _dbContext.Users.Add(user);
        } 
    }
}
