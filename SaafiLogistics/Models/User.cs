using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaafiLogistics.Models;
using SaafiLogistics.ViewModels;

namespace SaafiLogistics.Models
{
    public class User
    {

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Verify { get; set; }
        public int UserId { get; set; }
        private static int NextId = 1;

        public User()
        {
            UserId = NextId;
            NextId++;
        }
    }
}
