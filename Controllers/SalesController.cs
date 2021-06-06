using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestForASPCORE.Models;

namespace TestForASPCORE.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index(string searchText)
        {
            SalesContext salesContext = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.SalesContext)) as SalesContext;
            
            
            if (searchText != "" && searchText != null)
            {
                return View(salesContext.searchProduct(searchText));
            }
            else
            {
                return View(salesContext.getSalesDetails());
            }
        }

        public IActionResult InsertSales(Sales obj)
        {
            ProductContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.ProductContext)) as ProductContext;
            List<Product> productList = context.getProduct();
            ViewBag.productData = productList;
            SalesContext salesContext = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.SalesContext)) as SalesContext;
            ViewBag.billNo = salesContext.billNo();
            return View(obj);
        }
        [HttpPost]
        public IActionResult insertSales(Sales obj)
        {

            try
            {
                SalesContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.SalesContext)) as SalesContext;

                context.insert(obj);
                return RedirectToAction("InsertSales");

            }

            catch (Exception ex)
            {

                throw;
            }


        }

        public IActionResult getBillNo()
        {
            SalesContext salesContext = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.SalesContext)) as SalesContext;
            salesContext.addNewBill();
            return RedirectToAction("InsertSales");
        }
        [HttpGet]
        public IActionResult Delete(int id, int productId)
        {
            try
            {
                SalesContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.SalesContext)) as SalesContext;
                context.delete(id,productId);
                //return View(obj);
                return RedirectToAction("Index");

            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {

                throw;

            }
            catch (Exception ex)
            {

                throw;
            }


        }
        public IActionResult UpdateSales(Sales obj)
        {

            ProductContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.ProductContext)) as ProductContext;
            List<Product> productList = context.getProduct();
            ViewBag.productData = productList;
            //CustomerContext customerContext = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.CustomerContext)) as CustomerContext;
           // List<Supplier> customerList = customerContext.getCustomer();
           // ViewBag.customerData = 
            return View(obj);


        }
        [HttpPost]
        public IActionResult updateSales(Sales obj)
        {
            //if (ModelState.IsValid)
           // {
                try
                {


                    SalesContext context = HttpContext.RequestServices.GetService(typeof(TestForASPCORE.Models.SalesContext)) as SalesContext;

                    context.update(obj);

                    return RedirectToAction("Index");

                }

                catch (Exception ex)
                {
                    throw;

                }
            //}
            /**
            else
            {
                return RedirectToAction("UpdateSales");
            }**/


        }
    }
}
