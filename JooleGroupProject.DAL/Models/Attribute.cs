using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.DAL.Models
{
    public class Attribute
    {
       
        public int AttributeID { get; set; }

        public string AttributeName { get; set; }

        public bool IsTechSpec { get; set; }

        public bool IsType { get; set; }

        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }

        public virtual ICollection<TechSpecFilter> TechSpecFilters { get; set; }
    }
}
