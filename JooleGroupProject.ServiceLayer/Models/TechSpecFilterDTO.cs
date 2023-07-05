using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.ServiceLayer.Models
{
    public class TechSpecFilterDTO
    {
        public int SubCategoryID { get; set; }

        public int AttributeID { get; set; }

        public string AttributeName { get; set; }

        public int MaxValue { get; set; }

        public int MinValue { get; set; }

    }
}
