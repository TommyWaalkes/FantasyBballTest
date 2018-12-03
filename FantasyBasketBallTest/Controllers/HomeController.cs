using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace FantasyBasketBallTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //HttpWebRequest request = new HttpWebRequest();
            HttpWebRequest request = WebRequest.CreateHttp("https://www.fantasybasketballnerd.com/service/players");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader s = new StreamReader(response.GetResponseStream());
            string xml = s.ReadToEnd();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string json = JsonConvert.SerializeXmlNode(doc);
            JObject j = JObject.Parse(json);
            ViewBag.dat = j["FantasyBasketballNerd"]["Player"].ToList();
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
    }
}