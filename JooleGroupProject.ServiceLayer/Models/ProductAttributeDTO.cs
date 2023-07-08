using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.ServiceLayer.Models
{
    public class ProductAttributeDTO
    {
        public int ProductID { get; set; }
        public int AttributeID { get; set; }
        public string AttributeValue { get; set; }
        public string AttributeName { get; set; }
        public bool IsTechSpec { get; set; }
        public bool IsType { get; set; }

    }
}
