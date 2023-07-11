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

        // GET: Search
        public ActionResult Index()
        {
            SearchViewModel searchViewModel = new SearchViewModel()
            {
                Categories = searchService.GetCategories()
            };

            return View("Index", searchViewModel);
        }

        [HttpPost]
        public ActionResult selectCategory(string data ) 
        { 
            int categoryID = int.Parse(data);
            var subs = searchService.GetSubsforCategory(categoryID);
            string[] tags = new string[subs.Count];

            for (int i = 0; i < subs.Count; i++)
            {
                tags[i] = subs[i].SubCategoryName; 
            }

            return Json(new { tags });
        }

    }
}