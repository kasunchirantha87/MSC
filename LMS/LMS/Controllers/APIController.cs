using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using LMS.Models;

namespace LMS.Controllers
{
    public class APIController : Controller
    {
        // GET: API
        LMSEntities _LMSEntities;

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetStackOverflowApiList(string StackUser)
        {
            {
                return Json("Sucsess");
            }
        }
    }
}