using JooleGroupProject.ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.ServiceLayer.Interfaces
{
    public interface IProductService
    {

        ProductDTO GetProductById(int id);
        ProductDTO GetProductByName(string name);
        int GetTechSpecValueForProduct(int productID, int attributeID);


    }
}
