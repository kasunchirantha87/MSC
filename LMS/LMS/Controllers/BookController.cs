using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;

namespace LMS.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        LMSEntities _LMSEntities;
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getCategories()
        {
            using (_LMSEntities = new LMSEntities())
            {
                return Json(_LMSEntities.Categories.Select(c => new { CategoryName = c.CategoryName, CategoryID = c.CategoryID }).ToArray(),
                    JsonRequestBehavior.AllowGet);
            }
        }
    }
}