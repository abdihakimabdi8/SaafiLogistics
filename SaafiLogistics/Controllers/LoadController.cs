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
        //List<Load> loads = LoadData.FindAll();
        public IActionResult Index()
        {
            List<Load> AllLoads = LoadData.FindAll();
            return View(AllLoads);
        }
        public IActionResult Add()
        {
            AddLoadViewModel addLoadViewModel = new AddLoadViewModel();
            return View(addLoadViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddLoadViewModel addLoadViewModel)
        {
            // Add the new load to my existing loads
            Load newLoad = new Load

            {

                Date = AddLoadViewModel.Date,
                Number = AddLoadViewModel.Number,
                Description = AddLoadViewModel.Description,
                Owner = AddLoadViewModel.Owner,
                Pay = AddLoadViewModel.Pay,
                Advance = AddLoadViewModel.Advance,
                Net = AddLoadViewModel.Net
            };
            LoadData.Add(newLoad);

            return Redirect("/Process");
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
        public IActionResult Remove(int loadIds)
        {
            foreach (int LoadId in loadIds)
            {
                LoadData.Remove(loadIds);
            }

            return Redirect("/");
        }
    }
}
