using Microsoft.AspNetCore.Mvc;
using SaafiLogistics.Data;
using SaafiLogistics.ViewModels;
using SaafiLogistics.Models;
using System.ComponentModel.DataAnnotations;
namespace SaafiLogistics.Models
{
    public enum LoadFieldType
    {
        // Enum representing the LoadField properties of a Load
        // that can be viewed and searched.

        Date,
        Number,
        Description,
        Owner,
        All
    }
}
