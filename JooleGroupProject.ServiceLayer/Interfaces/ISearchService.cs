﻿using JooleGroupProject.ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.ServiceLayer.Interfaces
{
    public interface ISearchService
    {

        List<CategoryDTO> GetCategories();
       
        List<SubCategoryDTO> GetSubsforCategory(int id);

    }
}