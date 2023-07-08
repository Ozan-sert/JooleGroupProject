using JooleGroupProject.ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JooleGroupProject.UI.Models
{
    public class ProductListVM
    {
        public int SubCategoryID { get; set; }
        public IEnumerable<ProductDTO> Products { get; set; }
    }
}