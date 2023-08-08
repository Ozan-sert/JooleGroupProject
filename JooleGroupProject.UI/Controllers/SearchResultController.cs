using Antlr.Runtime.Tree;
using JooleGroupProject.ServiceLayer.Interfaces;
using JooleGroupProject.ServiceLayer.Models;
using JooleGroupProject.ServiceLayer.Services;
using JooleGroupProject.UI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace JooleGroupProject.UI.Controllers
{
    public class SearchResultController : Controller
    {
        // Instantiate the service layer
        private readonly ResultService resultService = new ResultService();
        private readonly SearchService searchService = new SearchService();
        private readonly ProductService productService = new ProductService();

        // GET: SearchResult
        public ActionResult Index(int subCategoryID, string categoryName, string subCategoryName)
        {
            SearchResultVM viewModel = new SearchResultVM();
            viewModel.techSpecFilters = resultService.GetTechSpecFilterNamesForSubCategory(subCategoryID);
            viewModel.CategoryName = categoryName;
            viewModel.SubCategoryName = subCategoryName;
            viewModel.SubCategoryID = subCategoryID;
            viewModel.Products = resultService.GetProductsBySubCategory(subCategoryID);
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult FilterProducts(string year1, string year2, List<int> attributeIDs, List<string> filterValueStrings, int subCategoryID)
        {
            int y1 = (year1 == ""||year1 == "0") ? 1900: int.Parse(year1);
            int y2 = (year2 == "" || year2 == "0") ? 2023 : int.Parse(year2);
            int subID = subCategoryID;
            IEnumerable<ProductDTO> products = resultService.GetProductsFiltered(subID, y1, y2);
            
            for(int i = 0; i < attributeIDs.Count;i++)
            {
                int attributeID = attributeIDs[i];
                var values = filterValueStrings[i].Split('-');
                int min = int.Parse(values[0]);
                int max = int.Parse(values[1]);
                products = products.Where(p =>
                {
                    int attributeValue = productService.GetTechSpecValueForProduct(p.ProductID, attributeID);

                    return attributeValue >= min && attributeValue <= max;
                }).ToList();
            }



            ProductListVM viewModel = new ProductListVM
            {
                SubCategoryID = subID,
                Products = products
            };

            return PartialView("_ProductListPartial", viewModel.Products); ;
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