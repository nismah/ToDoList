using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ToDoListUI.Models;

namespace ToDoListUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult User()
        {
            ViewBag.Message = "Your account page.";

            return View();
        }

        public ActionResult Member()
        {
            IList<MemberViewModel> members = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7207/api/");
                var responseTask = client.GetAsync("User/members");
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    members = JsonConvert.DeserializeObject<IList<MemberViewModel>>(readTask.Result);
                }
                else
                {
                    //Error response received   
                    members = new List<MemberViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return View(members);
        }
    }
}