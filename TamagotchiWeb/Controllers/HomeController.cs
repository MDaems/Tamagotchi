using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TamagotchiWeb.Controllers
{
    public class HomeController : Controller
    {
        TamagotchiServiceLocal.TamagotchiServiceClient service = new TamagotchiServiceLocal.TamagotchiServiceClient();

        public ActionResult Index()
        {
            List<TamagotchiServiceLocal.Tamagotchi> TamagotchiList = new List<TamagotchiServiceLocal.Tamagotchi>();
            foreach (TamagotchiServiceLocal.Tamagotchi item in service.GetAllTamagotchies())
            {
                TamagotchiList.Add(item);
            }
            ViewBag.Tamagotchis = TamagotchiList;
            return View();
        }

        public ActionResult About(int id)
        {
            TamagotchiServiceLocal.Tamagotchi tamagotchi = service.GetTamagotchi(id);
            //ViewBag.highestProperty = service.GetHighestProperty(tamagotchi);

            ViewBag.tamagotchi = tamagotchi;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}