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
        //public Attribute()
        //{
        //    AttributeValues = new HashSet<AttributeValue>();
        //    TechSpecFilters = new HashSet<TechSpecFilter>();
        //}

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AttributeID { get; set; }

        //[Required]
        //[StringLength(100)]
        public string AttributeName { get; set; }

        public bool IsTechSpec { get; set; }

        public bool IsType { get; set; }


        public virtual ICollection<AttributeValue> AttributeValues { get; set; }

        public virtual ICollection<TechSpecFilter> TechSpecFilters { get; set; }
    }
}
