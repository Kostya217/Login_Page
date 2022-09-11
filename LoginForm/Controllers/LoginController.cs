using LoginForm.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoginForm.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public List<UserModel> GetUser()
        {
            List<UserModel> users = new List<UserModel>
            {
                new UserModel{id = 1, username ="Adams", password = "uqqtsK", admin = false},
                new UserModel{id = 2, username = "Dulles", password = "BbrNTJ", admin = false},
                new UserModel{id = 3, username = "Elizabeth", password = "fBnmSN", admin = true},
                new UserModel{id = 4, username = "Kennedy", password = "xf9eGF", admin = false},
                new UserModel{id = 5, username = "George", password = "TAGHaR", admin = false},
                new UserModel{id = 6, username = "Walt", password = "aGh5MM", admin = false},
                new UserModel{id = 7, username = "Michael", password = "QSNK6t", admin = true},
                new UserModel{id = 8, username = "John", password = "A9rdR4", admin = false},
                new UserModel{id = 9, username = "Muriel", password = "trMzaG", admin=true},
                new UserModel{id = 10, username = "Loretta", password = "Rm9uMx", admin = false}

            };

            return users;
        }

        public IActionResult Verify(UserModel user)
        {
            var users = GetUser();

            var checkUsername = users.Where(u => u.username.Equals(user.username));

            var checkPassword = checkUsername.Where(p => p.password.Equals(user.password));


            if (checkPassword.Count() == 1)
            {
                var u = users.FirstOrDefault(u => u.username.Equals(user.username));
                return RedirectToAction("Check", "Home", new { id = u.id, username = u.username, password = u.password, admin = u.admin });
            }
            else
            {
                ViewBag.message = "Login Failed";
                return View("Error");
            }
        }
    }
}
