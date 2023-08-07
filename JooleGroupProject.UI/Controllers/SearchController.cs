using JooleGroupProject.ServiceLayer.Services;
using JooleGroupProject.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                Categories = searchService.GetCategories(),
            };

            return View(searchViewModel);
        }
    }
}