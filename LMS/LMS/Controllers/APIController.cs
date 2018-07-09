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

        public JsonResult getApiList()
        {
            using (_LMSEntities = new LMSEntities())
            {
                SearchStackOverflow("CAT");

                return Json(_LMSEntities.Categories.Select(c => new { CategoryName = c.CategoryName, CategoryID = c.CategoryID }).ToArray(),
                    JsonRequestBehavior.AllowGet);
            }
        }
        static void SearchStackOverflow(string y)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://api.stackoverflow.com/1.1/search?intitle=" + Uri.EscapeDataString(y));
            httpWebRequest.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            httpWebRequest.Method = "GET";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string responseText;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                responseText = streamReader.ReadToEnd();
            }
            var result = (SearchResult)new JavaScriptSerializer().Deserialize(responseText, typeof(SearchResult));                     
        }

        class SearchResult
        {
            public List<Question> questions { get; set; }
        }
        class Question
        {
            public string title { get; set; }
            public int answer_count { get; set; }
        }
    }
}