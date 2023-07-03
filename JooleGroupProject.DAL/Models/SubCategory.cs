using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.DAL.Models
{
    public class SubCategory
    {
        public int SubCategoryID { get; set; }

        public int CategoryID { get; set; }
        public string SubCategoryName { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<TechSpecFilter> TechSpecFilters { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
