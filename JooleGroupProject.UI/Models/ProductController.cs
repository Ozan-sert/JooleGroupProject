using JooleGroupProject.ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JooleGroupProject.UI.Models
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Detail(int id)
        {
            var products = Session["products"] as IEnumerable<ProductDTO>;
            if(products == null)
            {
                return HttpNotFound("Products not found in session.");
            }
            var product = products.Where(p => p.ProductID == id).FirstOrDefault();
            if(product == null)
            {
                return HttpNotFound("Product not found.");
            }
            return View(product);
        }
    }
}