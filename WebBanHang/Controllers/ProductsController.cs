using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductCategory(int id)
        {
            var item = db.Products.ToList();
            if (id > 0)
            {
                item = item.Where(x => x.ProductCategoryID == id).ToList();
            }
            return View(item);
        }
        public ActionResult Partial_ItemsByCateId()
        {
            //int pageSize = 8;
            //int pageIndex = page.HasValue ? page.Value : 1;
            //var result = db.Products.ToList().ToPagedList(pageIndex, pageSize);
            //return View(result);
            var item = db.Products.Where(x => x.IsActive).ToList();
            return PartialView("Partial_ItemsByCateId",item);
        }
        public ActionResult Detail(int id)
        {
            var item = db.Products.FirstOrDefault(p => p.Id == id);
            return View(item);
        }
        public ActionResult GetCategory() 
        {
      
            var context = new ApplicationDbContext();
            var listCategory = context.ProductCategories.ToList(); 
            return PartialView("GetCategory",listCategory);
        }
        public ActionResult GetProductByCategory(int id)
        {
            var context = new ApplicationDbContext();
            return View("Partial_ItemsByCateId", context.Products.Where(p => p.ProductCategoryID == id).ToList());
        }
        public ActionResult Search(string searchString)
        {
            var results =
                (from m in db.Products
                 where
                  m.Title.Contains(searchString)
                  || m.Alias.Contains(searchString)
                 select m);
                return View("Partial_ItemsByCateId", results);
        }
    }
}