using Microsoft.AspNetCore.Mvc;
using SaafiLogistics.Data;
using SaafiLogistics.ViewModels;
using SaafiLogistics.Models;
namespace SaafiLogistics.Models
{
    public class LoadField
    {
        public int ID { get; set; }
        private static int nextId = 1;

        public string Value { get; set; }

        public LoadField()
        {
            ID = nextId;
            nextId++;
        }

        public LoadField(string value) : this()
        {
            Value = value;
        }

        // Provide a basic case-insensitive search
        public bool Contains(string testValue)
        {
            return Value.ToLower().Contains(testValue.ToLower());
        }

        public override string ToString()
        {
            return Value;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return (obj as LoadField).ID == ID;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return ID;
        }

    }
}
