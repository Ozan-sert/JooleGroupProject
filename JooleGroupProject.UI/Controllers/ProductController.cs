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
            var categories = Session["categories"] as IEnumerable<CategoryDTO>;
            if (categories == null)
            {
                return HttpNotFound("categories not found in session.");
            }
            return View(product);
        }

        public ActionResult Compare(string productIds, string subcategoryName, string categoryName)
        {
            if (string.IsNullOrEmpty(productIds))
            {
                return HttpNotFound("No products to compare.");
            }
            string[] ids = productIds.Split(',');
            ProductListVM viewModel = new ProductListVM();

            List<ProductDTO> products = new List<ProductDTO>();
            foreach(var id in ids)
            {
                int productID = int.Parse(id);
                var product = Session["products"] as IEnumerable<ProductDTO>;
                if(product == null)
                {
                    return HttpNotFound("Products not found in session.");
                }
                var prod = product.Where(p => p.ProductID == productID).FirstOrDefault();
                if(prod == null)
                {
                    return HttpNotFound("Product not found.");
                }
                products.Add(prod);
            }
            viewModel.Products = products;
            viewModel.CategoryName = categoryName;
            viewModel.SubCategoryName = subcategoryName;
            // get subcategory name

            return View(viewModel);
        }
       
    }
}