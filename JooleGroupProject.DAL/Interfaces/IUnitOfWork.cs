using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.DAL.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        IProductRepo ProductRepo { get; }
        IUserRepo UserRepo { get; }


        int Save();
    }
}

