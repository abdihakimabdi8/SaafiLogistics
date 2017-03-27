using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SaafiLogistics.ViewModels
{
    public class AddLoadViewModel
    {
        [Required(ErrorMessage = "Please provide valid load date")]
       
        public string Date { get; set; }

        [Required(ErrorMessage = "Please provide valid load number")]
        [Display(Name = "Load Number")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Please provide valid load description")]
       
        public string Description { get; set; }

        [Required(ErrorMessage = "Please provide name of owner operator")]
        [Display(Name = "Owner Operator")]
        public string Owner { get; set; }

        [Required(ErrorMessage = "Please provide the amount of load pay")]
        [Display(Name = "Line Haul")]
        public string Pay { get; set; }

        [Required(ErrorMessage = "Please provide the amount ofmfuel and other advances")]
        public string Advance { get; set; }

        [Required(ErrorMessage = "Please provide the amount of net load pay")]
        [Display(Name = "Net Pay")]
        public string Net { get; set; }
    }
}
