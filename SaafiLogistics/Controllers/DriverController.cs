using Microsoft.AspNetCore.Mvc;
using SaafiLogistics.Models;
using System.Collections.Generic;
using SaafiLogistics.ViewModels;


namespace SaafiLogistics.Controllers
{
    public class DriverController : Controller
    {
        // GET: /<controller>/

        public IActionResult Index()
        {
            List<Driver> payroll = DriverData.FindAll();

            return View(payroll);
        }
        public IActionResult Add()
        {
            DriverViewModel driverViewModel = new DriverViewModel();
            return View(driverViewModel);
        }

        [HttpPost]
        public IActionResult Add(DriverViewModel driverViewModel)
        {
            if (ModelState.IsValid)
            {
                // Add the new cheese to my existing cheeses
                Driver driverInput = new Driver
                {
                    Date = driverViewModel.Date,
                    Number = driverViewModel.Number,
                    Description = driverViewModel.Description,
                    DriverName = driverViewModel.DriverName,
                    LoadMiles = driverViewModel.LoadMiles,
                    DeadMiles = driverViewModel.DeadMiles,
                    Rate = driverViewModel.Rate
                };
                DriverData.Add(driverInput);

                return Redirect("/List/Payroll");
            }

            return View(driverViewModel);
        }
        [HttpGet]
        [Route("/Load/Edit/{LoadId}")]
        public IActionResult Edit(int LoadId)
        {
            ViewBag.load = DriverData.GetById(LoadId);
            return View();
        }

        [HttpPost]
        [Route("/Load/Edit/{LoadId}")]
        public IActionResult Edit(Driver load)
        {
            DriverData.Save(load);
            return Redirect("/");
        }
        public IActionResult Remove()
        {
            ViewBag.title = "Remove Loads";
            ViewBag.loads = DriverData.FindAll();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] driverIds)
        {
            foreach (int DriverId in driverIds)
            {
                DriverData.Remove(DriverId);
            }

            return Redirect("/");
        }
    }
}
