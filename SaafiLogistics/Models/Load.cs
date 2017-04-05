using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaafiLogistics.Models;
using SaafiLogistics.ViewModels;


namespace SaafiLogistics.Models
{
    public class Load
    {
        public Date Date { get; set; }
        public Number Number { get; set; }
        public Description Description { get; set; }
        public Owner Owner { get; set; }
        public string Pay { get; set; }
        public string Advance { get; set; }
        public string Net { get; set; }
        public int LoadId { get; set; }

        private static int NextId = 1;

        
        public Load ()
        {
            LoadId = NextId;
            NextId++;
            }
        // Overridden so the List check in LoadData works.
       

    }
}
