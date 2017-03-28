using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SaafiLogistics.Models
{
    public class LoadData
  
    {
      //static bool IsDataLoaded = false;
        static private List<Load> allLoads = new List<Load>();
        

        public static List<Load> FindAll()
        {
            return allLoads;
        }

        public static void Add(Load newLoad)
        {
            allLoads.Add(newLoad);
        }
        public static Load GetById(int id)
        {
            return allLoads.Single(x => x.LoadId == id);
        }

        public static void Remove(int id)
        {
            Load loadToRemove = GetById(id);
            allLoads.Remove(loadToRemove);
                }
        public static void Save(Load load)
        {
            var loadIndex = allLoads.IndexOf(load);
            Remove(load.LoadId);
            allLoads.Insert(loadIndex, load);
        }
    }
}
