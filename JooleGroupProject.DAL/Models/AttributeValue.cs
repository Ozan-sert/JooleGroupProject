﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.DAL.Models
{
    public class AttributeValue
    {
        //[Key]
        //[Column(Order = 0)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        //[Key]
        //[Column(Order = 1)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AttributeID { get; set; }

        //[Key]
        //[Column("attributeValue", Order = 2)]
        //[StringLength(100)]
        public string AttributeValue1 { get; set; }

        public virtual Attribute Attribute { get; set; }

        public virtual Product Product { get; set; }
    }
}
