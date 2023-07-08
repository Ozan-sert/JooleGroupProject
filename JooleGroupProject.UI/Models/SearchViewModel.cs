using JooleGroupProject.ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JooleGroupProject.UI.Models
{
    public class SearchViewModel
    {
        public List<CategoryDTO> Categories { get; set; }

        public List<SubCategoryDTO> SubCategories { get; set; }

    }
}