using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.ServiceLayer.Models
{
    public class ProductAttributeDTO
    {
        public int ProductID { get; set; }
        public int AttributeID { get; set; }
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
    }
}
