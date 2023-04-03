﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
using WebBanHang.Models.EF;

namespace WebBanHang.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add(Contact model)
        {
            db.Contacts.Add(model);
            db.SaveChanges();
            return View();
        }
    }
}