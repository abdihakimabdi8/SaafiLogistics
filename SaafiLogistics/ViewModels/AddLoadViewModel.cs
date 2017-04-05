using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SaafiLogistics.Data;
using SaafiLogistics.Models;


namespace SaafiLogistics.ViewModels
{
    public class AddLoadViewModel
    {
        [Required(ErrorMessage = "Please provide valid date")]
       
        public Date Date { get; set; }

        [Required(ErrorMessage = "Please provide valid load number")]
        [Display(Name = "Load Number")]
        public Number Number { get; set; }

        [Required(ErrorMessage = "Please provide valid load description")]
       
        public Description Description { get; set; }

        [Required(ErrorMessage = "Please provide name of owner operator")]
        [Display(Name = "Owner Operator")]
        public Owner Owner { get; set; }

        [Required(ErrorMessage = "Please provide the amount of load pay")]
        [Display(Name = "Line Haul")]
        public string Pay { get; set; }

        [Required(ErrorMessage = "Please provide the amount ofmfuel and other advances")]
        public string Advance { get; set; }

        [Required(ErrorMessage = "Please provide the amount of net load pay")]
        [Display(Name = "Net Pay")]
        public string Net { get; set; }

        public List<SelectListItem> Dates { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Numbers { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Descriptions { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Owners { get; set; } = new List<SelectListItem>();
      //  public Owner Owner { get; internal set; }

       
       // public int EmployerID { get; set; }

        // TODO #3 - Included other fields needed to create a load,
        // with correct valudation attributes and display names.
     

        public AddLoadViewModel()
        {

            LoadData loadData = LoadData.GetInstance();

            foreach (Date field in loadData.Dates.ToList())
            {
                Dates.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }
            foreach (Number field in loadData.Numbers.ToList())
            {
                Numbers.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }
            foreach (Description field in loadData.Descriptions.ToList())
            {
                Descriptions.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

            foreach (Owner field in loadData.Owners.ToList())
            {
                Owners.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }
        }
    }
}
