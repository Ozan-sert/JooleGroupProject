using JooleGroupProject.ServiceLayer.Services;
using JooleGroupProject.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JooleGroupProject.UI.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {

           IResultService searchService = new ResultService();
            var result = searchService.GetIndividualProperties(1);
            return View(result);
        }
    }
}