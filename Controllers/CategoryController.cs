using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestForASPCORE.Models;

namespace TestForASPCORE.Controllers
{
    public class CategoryController : Controller
    {

        public IActionResult Index(string searchText)
        {
            ProductCategoryContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.ProductCategoryContext)) as ProductCategoryContext;
            if (searchText != "" && searchText != null)
            {
                return View(context.searchCatagories(searchText));
            }
            else
            {
                return View(context.getCategories());
            }
          
            
        }


        public IActionResult Insert(ProductCategory obj)
        {
            return View(obj);

        }
        [HttpPost]
        public IActionResult insertCategory(ProductCategory obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ProductCategoryContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.ProductCategoryContext)) as ProductCategoryContext;

                    context.insert(obj);
                    return RedirectToAction("Index");

                }

                catch (Exception ex)
                {

                    return RedirectToAction("Index");
                }
            }
            else

            {
                return RedirectToAction("Insert");
            }
            
        }
        public IActionResult Delete(int id)
        {
            try
            {
                ProductCategoryContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.ProductCategoryContext)) as ProductCategoryContext;

                context.delete(id);
                //return View(obj);
                return RedirectToAction("Index");

            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {

                string errorMessage = "The data is associated with other tables. Please remove the data ASsociations!";
                ViewBag.Message2 = errorMessage;
                return View("../Category/Index",ViewBag.Message2);

            }
            catch (Exception ex)
            {

                throw;
            }
            
            
        }
       



        public IActionResult Update(ProductCategory obj)
        {
            return View(obj);


        }
        [HttpPost]
        public IActionResult updateCategory(  ProductCategory obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //string conn = "server=localhost; port=3306; database=SimpleInventorySystem;user=root;password=;";
                    /**using (MySqlConnection conn = new MySqlConnection("server=localhost; port=3306; database=SimpleInventorySystem;user=root;password=;"))
                    {
                        conn.Open();
                        string query = "update productCatagory set productName = '" + obj.name + "' where id='" + obj.id + "'";
                        //String query2 = "update productCatagory set productName = '" + obj.name + "' where id=7";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                    }**/
                    ProductCategoryContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.ProductCategoryContext)) as ProductCategoryContext;

                    context.update(obj);

                    return RedirectToAction("Index");

                }

                catch (Exception ex)
                {
                    throw;

                }
            }
            else
            {
                return RedirectToAction("Update");
            }
            
            
        }

    }
    
}
