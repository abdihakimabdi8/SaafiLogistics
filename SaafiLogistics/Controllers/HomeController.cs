using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;


namespace SaafiLogistics.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Dictionary<string, string> actionChoices = new Dictionary<string, string>();
            actionChoices.Add("owner", "Owner");
            actionChoices.Add("driver", "Driver");

            ViewBag.actions = actionChoices;

            return View();
        }
    }
}
