using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SaafiLogistics.Models
{
    public class LoadData
  
    {
        static bool IsDataLoaded = false;
        static private List<Load> AllLoads = new List<Load>();
        

        public static List<Load> FindAll()
        {
           // LoadData();

            // Bonus mission: return a copy
            return AllLoads;
        }

        /*
         * Returns a list of all values contained in a given column,
         * without duplicates. 
         */
      /**  public static List<Load> FindAll(string column)
        {
          //  LoadData();

            List<string> values = new List<string>();

            foreach (Dictionary<string, string> load in AllLoads)
            {
                string aValue = load[column];

                if (!values.Contains(aValue))
                {
                    values.Add(aValue);
                }
            }

            // Bonus mission: sort results alphabetically
            values.Sort();
            return values;
        }

        /**
         * Search all columns for the given term
         */
        public static List<Load> FindByValue(string value)
        {
            // load data, if not already loaded
            // LoadData();
            
            List<Load> loads = new List<Load>();

            foreach (Load row in AllLoads)
            {

                foreach (string key in row.Keys)
                {
                    string aValue = row[key];

                    if (aValue.ToLower().Contains(value.ToLower()))
                    {
                        loads.Add(row);

                        // Finding one field in a job that matches is sufficient
                        break;
                    }
                }
            }

            return loads;
        }

        internal static List<string> FindAll(string column)
        {
            throw new NotImplementedException();
        }

        /**
* Returns results of search the jobs data by key/value, using
* inclusion of the search term.
*
* For example, searching for employer "Enterprise" will include results
* with "Enterprise Holdings, Inc".
*/
        public static List<Dictionary<string, string>> FindByColumnAndValue(string column, string value)
        {
            // load data, if not already loaded
          //  LoadData();

            List<Dictionary<string, string>> loads = new List<Dictionary<string, string>>();

            foreach (Load row in AllLoads)
            {
                string aValue = row[column];

                if (aValue.ToLower().Contains(value.ToLower()))
                {
                    loads.Add(row);
                }
            }

            return loads;
        }
        public static void Add(Load newLoad)
        {
            AllLoads.Add(newLoad);
        }
        public static Load GetById(int id)
        {
            return AllLoads.Single(x => x.LoadId == id);
        }

        public static void Remove(int id)
        {
            Load loadToRemove = GetById(id);
            AllLoads.Remove(loadToRemove);
                }
        public static void Save(Load load)
        {
            var loadIndex = AllLoads.IndexOf(load);
            Remove(load.LoadId);

            // Insert at the index of the removed cheese to ensure we keep order;
            AllLoads.Insert(loadIndex, load);
        }


        /**
                /*
                 * Load and parse data from job_data.csv
                 *
                private static void LoadData()
                {

                    if (IsDataLoaded)
                    {
                        return;
                    }

                    List<string[]> rows = new List<string[]>();

                    using (StreamReader reader = File.OpenText("Models/load_data.csv"))
                    {
                        while (reader.Peek() >= 0)
                        {
                            string line = reader.ReadLine();
                            string[] rowArrray = CSVRowToStringArray(line);
                            if (rowArrray.Length > 0)
                            {
                                rows.Add(rowArrray);
                            }
                        }
                    }

                    string[] headers = rows[0];
                    rows.Remove(headers);

                    // Parse each row array into a more friendly Dictionary
                    foreach (string[] row in rows)
                    {
                        Dictionary<string, string> rowDict = new Dictionary<string, string>();

                        for (int i = 0; i */
        /*< headers.Length; i++)
                {
                    rowDict.Add(headers[i], row[i]);
                }
                AllLoads.Add(rowDict);
            }

            IsDataLoaded = true;
        }

        
          Parse a single line of a CSV file into a string array
         *
        private static string[] CSVRowToStringArray(string row, char fieldSeparator = ',', char stringSeparator = '\"')
        {
            bool isBetweenQuotes = false;
            StringBuilder valueBuilder = new StringBuilder();
            List<string> rowValues = new List<string>();

            // Loop through the row string one char at a time
            foreach (char c in row.ToCharArray())
            {
                if ((c == fieldSeparator && !isBetweenQuotes))
                {
                    rowValues.Add(valueBuilder.ToString());
                    valueBuilder.Clear();
                }
                else
                {
                    if (c == stringSeparator)
                    {
                        isBetweenQuotes = !isBetweenQuotes;
                    }
                    else
                    {
                        valueBuilder.Append(c);
                    }
                }
            }

            // Add the final value
            rowValues.Add(valueBuilder.ToString());
            valueBuilder.Clear();

            return rowValues.ToArray();
        }*/
    }
}
