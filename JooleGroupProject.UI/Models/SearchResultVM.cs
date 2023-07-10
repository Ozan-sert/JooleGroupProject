using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JooleGroupProject.ServiceLayer;
using JooleGroupProject.ServiceLayer.Models;
using JooleGroupProject.ServiceLayer.Services;

namespace JooleGroupProject.UI.Models
{
    public class SearchResultVM
    {
        public int SubCategoryID { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }

        //public int Year1 { get; set; }
        //public int Year2 { get; set; }

        public List<TechSpecFilterDTO> techSpecFilters { get; set; }
        public IEnumerable<ProductDTO> Products { get; set; }

    }
}