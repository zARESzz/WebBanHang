using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
        public ActionResult Partial_ItemsByCateId()
        {
            var item = db.Products.Where(x => x.IsActive).ToList();
            return PartialView("Partial_ItemsByCateId", item);
        }
        public ActionResult GetCategory() 
        { 
            var context = new ApplicationDbContext();
            var listCategory = context.ProductCategories.ToList(); 
            return PartialView(listCategory);
        }
        public ActionResult GetProductByCategory(int id)
        {
            var context = new ApplicationDbContext();
            return View("Partial_ItemsByCateId", context.Products.Where(p => p.ProductCategoryID == id).ToList());
        }
    }
}