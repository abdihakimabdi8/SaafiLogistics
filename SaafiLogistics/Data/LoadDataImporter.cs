using System.Collections.Generic;
using System.IO;
using System.Text;
using SaafiLogistics.Models;

namespace SaafiLogistics.Data
{
    public class LoadDataImporter
    {
        private static bool IsDataLoaded = false;

        /**
         * Load and parse data from load_data.csv
         */
        internal static void LoadData(LoadData loadData)
        {

            if (IsDataLoaded)
            {
                return;
            }

            List<string[]> rows = new List<string[]>();

            using (StreamReader reader = File.OpenText("Data/load_data.csv"))
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

            /**
             * Parse each row array into a Load object.
             * Assumes CSV column ordering: 
             *      name,employer,location,position type,core competency
             */
            foreach (string[] row in rows)
            {
                Date date = loadData.Dates.AddUnique(row[0]);
                Number number = loadData.Numbers.AddUnique(row[1]);
                Description description = loadData.Descriptions.AddUnique(row[2]);
                Owner owner = loadData.Owners.AddUnique(row[3]);

                Load newLoad = new Load
                {
                  
                    Date = date,
                    Number = number,
                    Description = description,
                    Owner = owner,
                    Pay = row[4],
                    Advance = row[5],
                    Net = row[6]
                };
                loadData.Loads.Add(newLoad);
            }

            IsDataLoaded = true;
        }


        /**
         * Parse a single line of a CSV file into a string array
         */
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
        }
    }
}
