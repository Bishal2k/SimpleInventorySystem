using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestForASPCORE.Models;

namespace TestForASPCORE.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ProductContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.ProductContext)) as ProductContext;
            
            return View(context.getProduct());


        }
        public IActionResult InsertProduct(Product obj)
        {
            ProductCategoryContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.ProductCategoryContext)) as ProductCategoryContext;
            List<ProductCategory> list = context.getCategories();
            // List<ProductCategory> list2 = getCategory();
            ViewBag.productData = list;
            //ViewBag.productData = new List<string>() { "Android","iOs"};
            return View(obj);
        }
        [HttpPost]
        public IActionResult insertProduct(Product obj)
        {
            try
            {
                ProductContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.ProductContext)) as ProductContext;

                context.insert(obj);
                return RedirectToAction("Index");

            }

            catch (Exception ex)
            {

                return RedirectToAction("Index");
            }
        }
        private List<ProductCategory> getCategory()
        {
            return new List<ProductCategory>()
            {
                new ProductCategory(){ id=20, name="oppo"}
            };
        }
    }
}
