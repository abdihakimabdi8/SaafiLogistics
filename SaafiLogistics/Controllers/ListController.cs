using Microsoft.AspNetCore.Mvc;
using SaafiLogistics.Models;
using SaafiLogistics.Data;
using SaafiLogistics.ViewModels;
using System.Linq;
using System.Collections.Generic;

namespace SaafiLogistics.Controllers
{
    public class ListController : Controller
    {

        // Our reference to the data store
        private static LoadData loadData;

        static ListController()
        {
            loadData = LoadData.GetInstance();
        }

        // Lists options for browsing, by "column"
        public IActionResult Index()
        {
            LoadFieldsViewModel loadFieldsViewModel = new LoadFieldsViewModel();
            loadFieldsViewModel.Title = "View Load Fields";

            return View(loadFieldsViewModel);
        }

        // Lists the values of a given column, or all loads if selected
        public IActionResult Values(LoadFieldType column)
        {
            if (column.Equals(LoadFieldType.All))
            {
                SearchLoadsViewModel loadsViewModel = new SearchLoadsViewModel();
                loadsViewModel.Loads = loadData.Loads;
                loadsViewModel.Title = "All Loads";
                return View("Loads", loadsViewModel);
            }
            else
            {
                LoadFieldsViewModel loadFieldsViewModel = new LoadFieldsViewModel();

                IEnumerable<LoadField> fields;

                switch (column)
                {
                    case LoadFieldType.Date:
                        fields = loadData.Dates.ToList().Cast<LoadField>();
                        break;
                    case LoadFieldType.Number:
                        fields = loadData.Numbers.ToList().Cast<LoadField>();
                        break;
                    case LoadFieldType.Description:
                        fields = loadData.Descriptions.ToList().Cast<LoadField>();
                        break;
                    case LoadFieldType.Owner:
                    default:
                        fields = loadData.Owners.ToList().Cast<LoadField>();
                        break;
                }

                loadFieldsViewModel.Fields = fields;
                loadFieldsViewModel.Title = "All " + column + " Values";
                loadFieldsViewModel.Column = column;

                return View(loadFieldsViewModel);
            }
        }

        // Lists Jobs with a given field matching a given value
        public IActionResult Loads(LoadFieldType column, string value)
        {
            SearchLoadsViewModel loadsViewModel = new SearchLoadsViewModel();
            loadsViewModel.Loads = loadData.FindByColumnAndValue(column, value);
            loadsViewModel.Title = "Loads with " + column + ": " + value;

            return View(loadsViewModel);
        }
    }
}
