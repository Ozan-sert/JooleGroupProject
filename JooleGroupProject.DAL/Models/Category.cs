using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.DAL.Models
{
    public class Category
    {
        //public Category()
        //{
        //    SubCategories = new HashSet<SubCategory>();
        //}

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CategoryID { get; set; }

        //[Required]
        //[StringLength(50)]
        public string CategoryName { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
