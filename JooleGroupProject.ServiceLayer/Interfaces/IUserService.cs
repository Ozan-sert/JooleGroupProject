using JooleGroupProject.ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.ServiceLayer.Interfaces
{
    public interface IUserService
    {
        UserDTO Login(string UsernameOrEmail, string Password);
        void RegisterUser(UserDTO userDTO); 

    }
}
