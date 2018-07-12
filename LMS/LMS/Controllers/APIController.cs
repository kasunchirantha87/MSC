using LMS.Dto;
using LMS.Models;
using LMS.Util;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace LMS.Controllers
{
    public class APIController : Controller
    {
        // GET: API
        LMSEntities _LMSEntities;
        readonly DateTime epochUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);


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

        [HttpPost]
        public JsonResult GetGithubDataByUsername(string GitUsername)
        {
            GithubResponseDto gitResponse = new GithubResponseDto();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "mscApp");
                using (HttpResponseMessage response = client.GetAsync(ConfigurationData.GithubBaseUrl + "users/" + GitUsername).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        var json = content.ReadAsStringAsync().Result;
                        gitResponse = JsonConvert.DeserializeObject<GithubResponseDto>(json);
                    }
                }
            }
            return Json(gitResponse);
        }


        [HttpPost]
        public JsonResult GetTwitterDataByUsername(string TwitterUsername)
        {
            object twitterResponse = new object();
            string requiredActionUrl = "users/lookup.json";
            var oAuthHeader = new TwitterApi(
                ConfigurationData.TwitterConsumerKey,
                ConfigurationData.TwitterConsumerSecret,
                ConfigurationData.AccessToken,
                 ConfigurationData.AccessTokenSecret
                ).GetTwitterAuthHeader(requiredActionUrl);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", oAuthHeader);
                using (HttpResponseMessage response = client.GetAsync(
                    ConfigurationData.TwitterBaseUrl +
                    ConfigurationData.TwitterApiVersion +
                    "/" + requiredActionUrl + "?screen_name=" + TwitterUsername).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        var json = content.ReadAsStringAsync().Result;
                        twitterResponse = JsonConvert.DeserializeObject<object>(json);
                    }
                }
            }
            return Json(twitterResponse);
        }

        [HttpPost]
        public JsonResult GetSoDataByUserId(string SoUserId)
        {
            StackoverflowResponseDto stackoverflowResponse = new StackoverflowResponseDto();
            string requiredActionUrl = "users/";
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            using (HttpClient client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Add("User-Agent", "mscApp");
                using (HttpResponseMessage response = client.GetAsync(
                    ConfigurationData.StackOverflowBaseUrl +
                    ConfigurationData.StackOverflowApiVersion +
                    "/" + requiredActionUrl + SoUserId + "?site=stackoverflow").Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        var json = content.ReadAsStringAsync().Result;
                        stackoverflowResponse = JsonConvert.DeserializeObject<StackoverflowResponseDto>(json);
                    }
                }
            }
            return Json(stackoverflowResponse);
        }



    }
}