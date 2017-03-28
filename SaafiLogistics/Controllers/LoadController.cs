using Microsoft.AspNetCore.Mvc;
using SaafiLogistics.Models;
using System.Collections.Generic;
using SaafiLogistics.ViewModels;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SaafiLogistics.Controllers
{
    public class LoadController : Controller
    {
        // GET: /<controller>/
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            AddLoadViewModel addLoadViewModel = new AddLoadViewModel();
            return View(addLoadViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddLoadViewModel addLoadViewModel)
        {
            if (ModelState.IsValid)
            {
                // Add the new cheese to my existing cheeses
                Load newLoad = new Load
                {
                    Date = addLoadViewModel.Date,
                    Number = addLoadViewModel.Number,
                    Description = addLoadViewModel.Description,
                    Owner = addLoadViewModel.Owner,
                    Pay = addLoadViewModel.Pay,
                    Advance = addLoadViewModel.Advance,
                    Net = addLoadViewModel.Net
                };
                LoadData.Add(newLoad);

                return Redirect("/List/Loads");
            }

            return View(addLoadViewModel);
        }
        [HttpGet]
        [Route("/Load/Edit/{LoadId}")]
        public IActionResult Edit(int LoadId)
        {
            ViewBag.load = LoadData.GetById(LoadId);
            return View();
        }

        [HttpPost]
        [Route("/Load/Edit/{LoadId}")]
        public IActionResult Edit(Load load)
        {
            LoadData.Save(load);
            return Redirect("/");
        }
        public IActionResult Remove()
        {
            ViewBag.title = "Remove Loads";
            ViewBag.loads = LoadData.FindAll();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] loadIds)
        {
            foreach (int LoadId in loadIds)
            {
                LoadData.Remove(LoadId);
            }

            return Redirect("/");
        }
    }
}
