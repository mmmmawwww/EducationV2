using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Training.BLL.DTO;
using Training.BLL.Infrastructure;
using Training.BLL.Interfaces;
using Training.WEB.Models;

namespace Training.WEB.Controllers
{
    public class AccountController : Controller
    {
        IAccountService accountSevice;
        public AccountController(IAccountService serv)
        {
            accountSevice = serv;
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                int loginResult = accountSevice.Login(model.Login, model.Password);
                if (loginResult == 3)
                {
                    FormsAuthentication.SetAuthCookie(model.Login, true);
                    return RedirectToAction("Topic", "TopicPage");
                }
                    if (loginResult == 1)
                    {
                        FormsAuthentication.SetAuthCookie(model.Login, true);
                        return RedirectToAction("Admin", "AdminPanel");
                    }
                if(loginResult == 0)
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }

            }
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userDto = new UsersDTO
                {
                    UserName = model.Name,
                    UserLastname = model.LastName,
                    UserMiddlename = model.MiddleName,
                    TrainingGroup = model.Group,
                    Login = model.Login,
                    Password = model.Password,
                };
                bool registerResult = accountSevice.Register(userDto);                            
                if (registerResult)
                {
                    FormsAuthentication.SetAuthCookie(model.Login, true);
                    return RedirectToAction("Topic", "TopicPage");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }
            return View(model);

        }
    }
}