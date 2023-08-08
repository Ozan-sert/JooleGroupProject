using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.ServiceLayer.Models
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public int SubCategoryID { get; set; }
        public string ProductName { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int ModelYear { get; set; }
        public string Series { get; set; }
    }
}
