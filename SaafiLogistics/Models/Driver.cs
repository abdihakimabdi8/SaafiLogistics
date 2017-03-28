using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaafiLogistics.Models;
using SaafiLogistics.ViewModels;


namespace SaafiLogistics.Models
{
    public class Driver
    {
        public string Date { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public string DriverName { get; set; }
        public string LoadMiles { get; set; }
        public string DeadMiles { get; set; }
        public string Rate { get; set; }
        public int DriverId { get; set; }

        private static int NextId = 1;


        public Driver()
        {
            DriverId = NextId;
            NextId++;
        }
    }
}
