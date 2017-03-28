using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SaafiLogistics.ViewModels
{
    public class DriverViewModel
    {
        [Required(ErrorMessage = "Please provide valid load date")]

        public string Date { get; set; }

        [Required(ErrorMessage = "Please provide valid load number")]
        [Display(Name = "Load Number")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Please provide the pick up and drop - off city")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Please provide valid driver name")]
        [Display(Name = "Driver Name")]
        public string DriverName { get; set; }

        [Required(ErrorMessage = "Please provide the amount of load miles")]
        [Display(Name = "Load Miles")]
        public string LoadMiles { get; set; }

        [Required(ErrorMessage = "Please provide the amount dedheaded miles")]
        [Display(Name = "Dead Miles")]
        public string DeadMiles { get; set; }

        [Required(ErrorMessage = "Please provide the driver mileage rate")]
        [Display(Name = "Rate")]
        public string Rate { get; set; }
    }
}
