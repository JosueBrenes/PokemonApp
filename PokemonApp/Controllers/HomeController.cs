using PokemonApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokemonApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var usuarioActual = Session["UsuarioActual"] as Usuarios; 
            if (usuarioActual != null)
            {
                ViewBag.RolId = usuarioActual.RolId;
            }
            else
            {
                ViewBag.RolId = 0; 
            }

            return View();
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}