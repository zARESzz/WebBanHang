
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebBanHang.Models;
using WebBanHang.Models.EF;
using System.Web.Http.Cors;

namespace WebBanHang.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class ProuductsApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext() { };
        //GET: api/bookAPI
       
        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }
        [HttpGet]
        [Route("API/ProuductsApi/GetCatgory")]

        public List<ProductCategory> GetCatgory()
        {
            return db.ProductCategories.ToList();
        }
        [Route("API/ProuductsApi/InsertProducts")]
        public void InsertBook(Product book)
        {
            db.Products.Add(book);
            db.SaveChanges();
        }
        [HttpGet]
        [Route("API/ProuductsApi/Search")]
        [AllowAnonymous]
        public IHttpActionResult Search(string keySearch)
        {
            if (string.IsNullOrEmpty(keySearch))
                return Ok(db.Products.Include(p => p.ProductCategory));
            var books = db.Products.Where(p => p.Title.ToLower()
            .Contains(keySearch.ToLower()))
            .Include(b => b.ProductCategory).ToList();
            return Ok(books);
        }
        [HttpDelete]
        [Route("API/ProuductsApi/Delete")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var book = db.Products.FirstOrDefault(p => p.Id == id);
                if (book == null)
                {
                    return NotFound();
                }
                db.Products.Remove(book);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }

        }
        [HttpPut]
        [Route("API/ProuductsApi/PutProduct")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product book)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != book.Id)
                {
                    return BadRequest();
                }

                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception)
            {
                return NotFound();

            }

        }
    }
}
