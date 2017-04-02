using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TamagotchiWeb.Controllers
{
    public class HomeController : Controller
    {
        Tamagotchi_Service.TamagotchiServiceClient service = new Tamagotchi_Service.TamagotchiServiceClient();
        List<Tamagotchi_Service.Tamagotchi> TamagotchiList = new List<Tamagotchi_Service.Tamagotchi>();

        public HomeController()
        {
            // Dynamically create new timer
            System.Timers.Timer timScheduledTask = new System.Timers.Timer();

            // Timer interval is set in miliseconds,
            timScheduledTask.Interval = 10000;

            timScheduledTask.Enabled = true;

            // Add handler for Elapsed event
            timScheduledTask.Elapsed +=
            new System.Timers.ElapsedEventHandler(timScheduledTask_Elapsed);
        }

        void timScheduledTask_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // Execute some task
            Console.WriteLine("Update");
            foreach (var item in TamagotchiList)
            {
                service.ApplyGameRules(service.GetTamagotchi(item.ID));
            }
        }  

        // GET: Index
        public ActionResult Index()
        {  
            foreach (Tamagotchi_Service.Tamagotchi item in service.GetAllTamagotchies())
            {
                TamagotchiList.Add(item);
            }
            ViewBag.Tamagotchis = TamagotchiList;
            return View();
        }

        // GET: Index
        public ActionResult About(int id)
        {
            Tamagotchi_Service.Tamagotchi tamagotchi = service.GetTamagotchi(id);

            ViewBag.Message = "Your detail page.";
            ViewBag.tamagotchi = tamagotchi;
            ViewBag.state = tamagotchi.State;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // POST: Detail
        public RedirectToRouteResult Add()
        {
            string name = Request.Form["tbName"];
            service.AddTamagotchi(name);

            ViewBag.result = "success";

            return RedirectToAction("");
        }
        // POST: Detail
        public RedirectToRouteResult Action()
        {
            string action = Request.Form["btAction"];
            int id = Convert.ToInt32(Request.Form["tbID"].ToString());

            string result = "Update";

            switch (action)
            {
                case "Eat":
                   service.Eat(id);
                    break;
                case "Sleep":
                    service.Sleep(id);
                    break;
                case "Hug":
                  service.Hug(id);
                    break;
                case "Play":
                   service.Play(id);
                    break;
            }

            return RedirectToAction("About", new { id = id, message = result });
        }
    }
}