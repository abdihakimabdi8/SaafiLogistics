using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SaafiLogistics.Models;
using SaafiLogists.Controllers;

namespace SaafiLogistics.Controllers
{
    public class SearchController : Controller
    {

        List<Load> loads = LoadData.FindAll();
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }
        
        [HttpPost]

        [Route("/Search")]
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices;
            if (searchType.Equals("all"))
            {

                List<Load> loads = LoadData.FindByValue(searchTerm);
                ViewBag.title = "All Loads";
                ViewBag.loads = loads;
                return View();
            }
            else
            {
                List<Dictionary<string, string>> loads = LoadData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.title = "Loads with " + ViewBag.columns[searchType] + ": " + searchTerm;
                ViewBag.loads = loads;

                return View();
            }
        }
    }
}
