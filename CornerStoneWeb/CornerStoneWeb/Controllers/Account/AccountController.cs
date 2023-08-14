using CornerStoneWeb.Data;
using CornerStoneWeb.Models.Account;
using CornerStoneWeb.Models.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CornerStoneWeb.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly ApplicationContext _context;

        public AccountController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var data = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Mobile = model.Mobile,
                    Password = model.Password,
                    IsActive = model.IsActive
                };
                _context.Users.Add(data);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Registration Successfully. Kindly Login to Proceed Further!";
                return RedirectToAction("Login");
            }
            else
            {
                return View(model);
            }
        }

        [AcceptVerbs("Post","Get")]
        public IActionResult UserNameIsExist(string UserName)
        {
            var data = _context.Users.Where(x => x.UserName == UserName).SingleOrDefault();
            if (data != null)
            {
                return Json($"UserName {UserName} already in use!");      
            }
            else
            {
                return Json(true);
            }
           
        }

            [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginSignUpViewModel model)
        {
            if (ModelState.IsValid)
            {

                var data = _context.Users.Where(x => x.UserName == model.UserName).SingleOrDefault();
                if (data != null)
                {
                    bool isValid = (data.UserName == model.UserName && data.Password == model.Password);
                    if (isValid)
                    {
                        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.UserName) },
                            CookieAuthenticationDefaults.AuthenticationScheme);

                        var principal = new ClaimsPrincipal(identity);

                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                        HttpContext.Session.SetString("UserName", model.UserName);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Invalid Password!";
                        return View(model);
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Username not found!";
                    return View(model);
                }
            }

            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
