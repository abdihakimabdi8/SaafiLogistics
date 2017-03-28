using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SaafiLogistics.Models
{
    public class DriverData

    {
        //static bool IsDataLoaded = false;
        static private List<Driver> payroll = new List<Driver>();


        public static List<Driver> FindAll()
        {
            // LoadData();

            // Bonus mission: return a copy
            return payroll;
        }

     
        public static void Add(Driver newLoad)
        {
            payroll.Add(newLoad);
        }
        public static Driver GetById(int id)
        {
            return payroll.Single(x => x.DriverId == id);
        }

        public static void Remove(int id)
        {
            Driver loadToRemove = GetById(id);
            payroll.Remove(loadToRemove);
        }
        public static void Save(Driver load)
        {
            var loadIndex = payroll.IndexOf(load);
            Remove(load.DriverId);

            payroll.Insert(loadIndex, load);
        }
    }
}
