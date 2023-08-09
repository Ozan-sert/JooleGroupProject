using JooleGroupProject.ServiceLayer.Models;
using JooleGroupProject.ServiceLayer.Services;
using JooleGroupProject.UI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace JooleGroupProject.UI.Controllers
{
    public class SearchController : Controller
    {
        SearchService searchService = new SearchService();
        SearchViewModel searchViewModel = new SearchViewModel();

        //public SearchController() {
        //    this.searchViewModel = new SearchViewModel()
        //    {
        //        selectedCategoryID = 1,
        //        selectedCategoryName = "Mechanical",
        //        Categories = searchService.GetCategories(),
        //        SubCategories = searchService.GetSubsforCategory(1),
        //    };
        //}

        // GET: Search
        public ActionResult Index()
        {
            this.searchViewModel = new SearchViewModel()
            {
                selectedCategoryID = 1,
                selectedCategoryName = "Mechanical",
                Categories = searchService.GetCategories(),
                SubCategories = searchService.GetSubsforCategory(1),
            };

            return View("Index", searchViewModel);
        }

        [HttpPost]
        public ActionResult selectCategory(string data = "1") { 
            int categoryID = int.Parse(data);
            string categoryName = searchService.GetCategoryNameByID(categoryID);

            searchViewModel = new SearchViewModel()
            {
                selectedCategoryID = categoryID,
                selectedCategoryName = categoryName,
                Categories = searchService.GetCategories(),
                SubCategories = searchService.GetSubsforCategory(categoryID)
            };

            var subs = searchService.GetSubsforCategory(categoryID);
            string[] tags = new string[subs.Count];

            for (int i = 0; i < subs.Count; i++)
            {
                tags[i] = subs[i].SubCategoryName; 
            }

            //Response.Cache.SetNoStore(); 
            return Json(new { tags });
        }

        [HttpPost]
        public ActionResult toResult(string data) {
            var selectedSubCategory = searchService.GetSubCategoryByName(data);

            searchViewModel.selectedSubCategoryName = data;
            searchViewModel.selectedSubCategoryID = selectedSubCategory.SubCategoryID;

            string result = "ProductResult?subCategoryID=" + searchViewModel.selectedSubCategoryID + "&categoryName=1" + "&subCategoryName=" + searchViewModel.selectedSubCategoryName;
            
            return Json(result); 

        }

        public ActionResult ProductResult(string subCategoryID, string categoryName, string subCategoryName) {
            SearchViewModel model = new SearchViewModel()
            {
                selectedCategoryName = categoryName, 
                selectedSubCategoryID = int.Parse(subCategoryID), 
                selectedSubCategoryName = subCategoryName, 
            }; 
            return View("ProductResult", model); 
        }

    }
}