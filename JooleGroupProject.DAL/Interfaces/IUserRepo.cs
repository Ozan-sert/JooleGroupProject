using JooleGroupProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.DAL.Interfaces
{
    public interface IUserRepo 
    { 
        

        // when login ==> get the password
        User GetUserByName(string name);

        void AddUser(User user); 
    }
}
