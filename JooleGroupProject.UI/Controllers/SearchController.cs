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
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace JooleGroupProject.UI.Controllers
{
    public class SearchController : Controller
    {
        SearchService searchService = new SearchService();
        //SearchViewModel searchViewModel = new SearchViewModel();

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
            SearchViewModel searchViewModel = new SearchViewModel()
            {
                //selectedCategoryID = 1,
             
                Categories = searchService.GetCategories(),
                //SubCategories = searchService.GetSubsforCategory(1),
            };

            return View("Index", searchViewModel);
        }

        [HttpPost]
        public ActionResult selectCategory(string data ) { 
            int categoryID = int.Parse(data);
           //  string categoryName = searchService.GetCategoryNameByID(categoryID);

            //SearchViewModel searchViewModel = new SearchViewModel()
            //{
            //    selectedCategoryID = categoryID,
           
            //    Categories = searchService.GetCategories(),
            //    SubCategories = searchService.GetSubsforCategory(categoryID)
            //};

            var subs = searchService.GetSubsforCategory(categoryID);
            string[] tags = new string[subs.Count];

            for (int i = 0; i < subs.Count; i++)
            {
                tags[i] = subs[i].SubCategoryName; 
            }

            //Response.Cache.SetNoStore(); 
            return Json(new { tags });
        }

        //[HttpPost]
        //public ActionResult toResult(string data) {
        //    var selectedSubCategory = searchService.GetSubCategoryByName(data);
        //    SearchViewModel searchViewModel = new SearchViewModel() {
        //        selectedSubCategoryName = data,
        //        selectedSubCategoryID = selectedSubCategory.SubCategoryID,
        //        selectedCategoryID = selectedSubCategory.CategoryID,
        //        Categories = searchService.GetCategories(), 
        //        SubCategories = searchService.GetSubsforCategory(selectedSubCategory.CategoryID),
        //    };

        //    //string result = "/Search/ProductResult?subCategoryID=" + searchViewModel.selectedSubCategoryID + "&categoryName=1" + "&subCategoryName=" + searchViewModel.selectedSubCategoryName;
            
        //    return Json(searchViewModel); 

        //}

       
        public ActionResult ProductResult(string result) {
            if (!string.IsNullOrEmpty(result))
            {
                // Decode and deserialize the JSON data
                // decodedData = HttpUtility.UrlDecode(data);
                var serializer = new JavaScriptSerializer();
                var myObject = serializer.Deserialize<SearchViewModel>(result);

                return View("ProductResult", myObject);
                // Now you can work with the myObject as needed

                // For example:
            }
            //{
            //    selectedCategoryName = categoryName, 
            //    selectedSubCategoryID = int.Parse(subCategoryID), 
            //    selectedSubCategoryName = subCategoryName, 
            //}; 
            return View("Index"); 
        }

    }
}