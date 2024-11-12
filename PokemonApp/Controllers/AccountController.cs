using PokemonApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokemonApp.Controllers
{
    

    namespace PokemonApp.Controllers
    {
        public class AccountController : Controller
        {
            [HttpGet]
            public IActionResult Login()
            {
                return View(new LoginViewModel());
            }

            [HttpPost]
            public IActionResult Login(LoginViewModel model)
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                if (model.Username != "AshKetchum" || model.Password != "Pikachu123")
                {
                    model.ErrorMessage = "The provided username or password is incorrect.";
                    return View(model);
                }

                return RedirectToAction("Dashboard", "Trainer");
            }
        }
    }
