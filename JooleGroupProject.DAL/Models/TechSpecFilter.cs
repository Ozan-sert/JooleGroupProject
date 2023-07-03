using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.DAL.Models
{
    public class TechSpecFilter
    {

        //[Key]
        //[Column(Order = 0)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubCategoryID { get; set; }

        //[Key]
        //[Column(Order = 1)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AttributeID { get; set; }

        //[Key]
        //[Column(Order = 2)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaxValue { get; set; }

        //[Key]
        //[Column(Order = 3)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MinValue { get; set; }

        public virtual Attribute Attribute { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}

