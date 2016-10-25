using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OneCoin.Service.Helper.Http;
using OneCoin.Service.Helper.Serialization;
using Newtonsoft.Json.Linq;

namespace OneCoin.Service.Payment.WebTest.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            
            var client = new HttpClient("http://localhost:7999/orders/GetTestOrderNo");
              
            ViewBag.Data = client.GetString();
             
            
            return View();
        }


        public ActionResult CallBack()
        {
            return View(Spanner.GetHttpFormData());
        }
    }


     
}
