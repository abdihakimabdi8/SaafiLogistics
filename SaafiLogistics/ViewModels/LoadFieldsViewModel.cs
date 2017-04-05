using System;
using System.Collections.Generic;
using SaafiLogistics.Models;

namespace SaafiLogistics.ViewModels
{
    public class LoadFieldsViewModel
    {

        // The current column
        public LoadFieldType Column { get; set; }

        // All fields in the given column
        public IEnumerable<LoadField> Fields { get; set; }

        // All columns, for display
        public List<LoadFieldType> Columns { get; set; }

        // View title
        public string Title { get; set; } = "";

        public LoadFieldsViewModel()
        {
            // Populate the list of all columns

            Columns = new List<LoadFieldType>();

            foreach (LoadFieldType enumVal in Enum.GetValues(typeof(LoadFieldType)))
            {
                Columns.Add(enumVal);
            }
        }
    }
}
