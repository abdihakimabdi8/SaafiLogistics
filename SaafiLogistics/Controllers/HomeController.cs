﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace SaafiLogistics.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Dictionary<string, string> actionChoices = new Dictionary<string, string>();
            actionChoices.Add("owner", "Owner");
            actionChoices.Add("driver", "Driver");

            ViewBag.type = actionChoices;

            return View();
        }
    }
}
