using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.DAL.Models
{
    public class Product
    {
        //public Product()
        //{
        //    AttributeValues = new HashSet<AttributeValue>();
        //}

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        public int SubCategoryID { get; set; }

        //[Required]
        //[StringLength(100)]
        public string ProductName { get; set; }

        //[Required]
        //[StringLength(100)]
        public string Model { get; set; }

        //[Required]
        //[StringLength(100)]
        public string Manufacturer { get; set; }

        public int ModelYear { get; set; }

        //[Required]
        //[StringLength(100)]
        public string Series { get; set; }
        public virtual ICollection<ProductAttribute> AttributeValues { get; set; }

        public virtual SubCategory SubCategory { get; set; }

    }
}
