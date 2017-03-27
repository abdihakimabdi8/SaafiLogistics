using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SaafiLogistics.Models;
using SaafiLogistics.ViewModels;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SaafiLogistics.Controllers
{
    public class UserController : Controller
    {

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<User> users = UserData.GetAll();
            return View(users);
        }
        public IActionResult Add()
        {
            AddUserViewModel AddUserViewModel = new AddUserViewModel();

            return View(AddUserViewModel);
        }
        [HttpPost]

        public IActionResult Add(AddUserViewModel AddUserViewModel)

        {
            User newUser = new User
            {
                UserName = AddUserViewModel.UserName,
                Email = AddUserViewModel.Email,
                Password = AddUserViewModel.Password,
                Verify = AddUserViewModel.Verify

            };
            UserData.Add(newUser);
            return Redirect("/User");
        }
    }
}
