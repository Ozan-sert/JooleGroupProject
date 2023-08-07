using JooleGroupProject.ServiceLayer.Interfaces;
using JooleGroupProject.ServiceLayer.Models;
using JooleGroupProject.ServiceLayer.Services;
using JooleGroupProject.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JooleGroupProject.UI.Controllers
{
    public class SearchResultController : Controller
    {
        // Instantiate the service layer
        private readonly ResultService resultService = new ResultService();
        private readonly SearchService searchService = new SearchService();


        // GET: SearchResult
        public ActionResult Index(int subCategoryID, string categoryName, string subCategoryName)
        {
            SearchResultVM viewModel = new SearchResultVM();
            viewModel.techSpecFilters = resultService.GetTechSpecFilterNamesForSubCategory(subCategoryID);
            viewModel.CategoryName = categoryName;
            viewModel.SubCategoryName = subCategoryName;
            return View(viewModel);
        }


        // Test Services:
        public ActionResult TechSpecFilters(int subCategoryID)
        {
            SearchResultVM viewModel = new SearchResultVM();
            viewModel.techSpecFilters = resultService.GetTechSpecFilterNamesForSubCategory(subCategoryID);
            return View(viewModel.techSpecFilters);
        }

        public ActionResult ProducsInSubcategory(int subCategoryID)
        {
            SearchResultVM viewModel = new SearchResultVM();
            viewModel.Products = resultService.GetProductsBySubCategory(subCategoryID);
            return View(viewModel.Products);
        }
        public ActionResult ProductsFilteredByModelYear(int sub, int year1, int year2)
        {
            SearchResultVM viewModel = new SearchResultVM();
            viewModel.Products = resultService.GetProductsFiltered(sub, year1, year2);
            return View(viewModel.Products);
        }
    }
}