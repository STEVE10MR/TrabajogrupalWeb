using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajoGrupal.Models;

namespace TrabajoGrupal.Controllers
{
    public class AccountController : Controller
    {
        private List<ClsUser> _userList;
        private List<ClsUserProfile> _userProfileList;
        

        public AccountController()
        {
            _userList = new List<ClsUser>();
            _userProfileList = new List<ClsUserProfile>();

            _userList.Add(new ClsUser
            {
                Id = 1,
                Username = "usuario1",
                Password = "password1",
                Email = "usuario1@ejemplo.com",
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });

            _userList.Add(new ClsUser
            {
                Id = 2,
                Username = "usuario2",
                Password = "password2",
                Email = "usuario2@ejemplo.com",
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });

            _userProfileList.Add(new ClsUserProfile
            {
                Id = 1,
                UserId = 1,
                FullName = "Usuario Uno",
                IsPublic = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });

            _userProfileList.Add(new ClsUserProfile
            {
                Id = 2,
                UserId = 2,
                FullName = "Usuario Dos",
                IsPublic = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });
        }

        [HttpGet]
        public ActionResult Login()
        {
            return PartialView("~/Views/Account/Login.cshtml", new ClsUser());
        }

        [HttpPost]
        public ActionResult Login(ClsUser model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("~/Views/Account/Login.cshtml", model);
            }

            var user = _userList.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);
            if (user == null)
            {
                ModelState.AddModelError("", "El usuario o la contraseña son incorrectos.");
                return View(new ClsUser());
            }
            else
            {
                Session["UserId"] = user.Id;
                return View("~/Views/Shared/_LoggedInUser.cshtml", user);
            }
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Default");
        }
    }
}