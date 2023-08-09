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

        public SearchController() {
            this.searchViewModel = new SearchViewModel()
            {
                selectedCategoryID = 1,
                selectedCategoryName = "Mechanical",
                Categories = searchService.GetCategories(),
                SubCategories = searchService.GetSubsforCategory(1),
            };
        }

        // GET: Search
        public ActionResult Index()
        {

            return View(this.searchViewModel);
        }

        [HttpPost]
        public ActionResult selectCategory(string data = "1") { 
            int categoryID = int.Parse(data);
            string categoryName = searchService.GetCategoryNameByID(categoryID);

            this.searchViewModel = new SearchViewModel()
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

            if (selectedSubCategory == null) {
                return View("SearchError"); 
            }

            searchViewModel.selectedSubCategoryName = data;
            searchViewModel.selectedSubCategoryID = selectedSubCategory.SubCategoryID; 

            return View("ProductResult", searchViewModel); 

        }

    }
}