using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaafiLogistics.Models;
using SaafiLogistics.ViewModels;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860



namespace SaafiLogists.Controllers
{
    public class ListController : Controller
    {
        internal static Dictionary<string, string> columnChoices = new Dictionary<string, string>();
        List<Driver> payroll = DriverData.FindAll();
        List<Load> AllLoads = LoadData.FindAll();
        // This is a "static constructor" which can be used
        // to initialize static members of a class
        static ListController()
        {
            columnChoices.Add("date", "Date");
            columnChoices.Add("load number", "Load Number");
            columnChoices.Add("description", "Description");
            columnChoices.Add("owner", "Owner");
            columnChoices.Add("line haul", "Line Haul");
            columnChoices.Add("advance ", "Advance");
            columnChoices.Add("net", "Net");

        }

        public IActionResult Index()
        {
            ViewBag.columns = columnChoices;
            return View();
        }

        public IActionResult Loads(string column)
        {
            List<Load> allLoads = LoadData.FindAll();

            return View(allLoads);
        }
        public IActionResult Payroll(string column)
        { 
            List<Driver> payroll = DriverData.FindAll();
            return View(payroll);
        }



            /**if (column.Equals("all"))
            {
                List<Load> AllLoads = LoadData.FindAll();
                return View("Loads");
            }
            else
            {
                return View("loads");
            }
            /**     else
                 {
                     List<string> items = LoadData.FindAll(column);
                     ViewBag.title = "All " + columnChoices[column] + " Values";
                     ViewBag.column = column;
                     ViewBag.items = items;
                     return View();
                 }
             }

             public IActionResult Loads(string column, string value)
             {
                 List<Dictionary<string, string>> loads = LoadData.FindByColumnAndValue( column,  value);
                 ViewBag.title = "Loads with " + columnChoices[column] + ": " + value;
                 ViewBag.loads = loads;

                 return View();
             }**/
        }
    }

