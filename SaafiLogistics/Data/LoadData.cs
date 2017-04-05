using System;
using System.Collections.Generic;
using System.Linq;
using SaafiLogistics.Models;
using SaafiLogistics.ViewModels;
namespace SaafiLogistics.Data
{
    class LoadData
    {
        /**
         * A data store for Load objects
         */

        public List<Load> Loads { get; set; } = new List<Load>();
        public LoadFieldData<Date> Dates { get; set; } = new LoadFieldData<Date>();
        public LoadFieldData<Number> Numbers { get; set; } = new LoadFieldData<Number>();
        public LoadFieldData<Description> Descriptions { get; set; } = new LoadFieldData<Description>();
        public LoadFieldData<Owner> Owners { get; set; } = new LoadFieldData<Owner>();
        internal static LoadData GetInstance(int id)
        {
            throw new NotImplementedException();
        }

        private LoadData()
        {
            LoadDataImporter.LoadData(this);
        }

        private static LoadData instance;
        public static LoadData GetInstance()
        {
            if (instance == null)
            {
                instance = new LoadData();
            }

            return instance;
        }


        /**
         * Return all Load objects in the data store
         * with a field containing the given term
         */
        public List<Load> FindByValue(string value)
        {
            var results = from l in Loads
                          where l.Owner.Contains(value)
                          || l.Date.Contains(value)
                          || l.Description.Contains(value)
                          || l.Number.Contains(value)
                          select l;

            return results.ToList();
        }


        /**
         * Returns results of search the jobs data by key/value, using
         * inclusion of the search term.
         */
        public List<Load> FindByColumnAndValue(LoadFieldType column, string value)
        {
            var results = from l in Loads
                          where GetFieldByType(l, column).Contains(value)
                          select l;

            return results.ToList();
        }

        /**
         * Returns the JobField of the given type from the Job object,
         * for all types other than JobFieldType.All. In this case, 
         * null is returned.
         */
        public static LoadField GetFieldByType(Load load, LoadFieldType type)
        {
            switch (type)
            {
                case LoadFieldType.Date:
                    return load.Date;
                case LoadFieldType.Number:
                    return load.Number;
                case LoadFieldType.Description:
                    return load.Description;
                case LoadFieldType.Owner:
                    return load.Owner;
            }

            throw new ArgumentException("Cannot get field of type: " + type);
        }

        internal List<Load> FindByValue(object value)
        {
            throw new NotImplementedException();
        }


        /**
         * Returns the Job with the given ID,
         * if it exists in the store
         */
        public Load Find(int id)
        {
            var results = from l in Loads
                          where l.LoadId == id
                          select l;

            return results.Single();
        }

    }
}
