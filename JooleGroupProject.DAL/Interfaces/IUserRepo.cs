using JooleGroupProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.DAL.Interfaces
{
    public interface IUserRepo : IGenericRepo<User>
    { 
        

        // when login ==> get the password
        User GetUserByName(string name);

        User GetUserByEmail(string email); 

        void AddUser(User user); 
    }
}
