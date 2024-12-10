using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using PokemonApp.Models;

namespace PokemonApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly DatabaseEntities db = new DatabaseEntities();

        private byte[] HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPassword(byte[] hashedPassword, string passwordToCheck)
        {
            var passwordToCheckHash = HashPassword(passwordToCheck);
            return hashedPassword.SequenceEqual(passwordToCheckHash);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Usuario1, string Contraseña)
        {
            if (string.IsNullOrEmpty(Usuario1) || string.IsNullOrEmpty(Contraseña))
            {
                ModelState.AddModelError("", "Both username and password are required.");
                return View();
            }

            var usuario = db.Usuarios1.FirstOrDefault(u => u.Usuario1 == Usuario1);

            if (usuario != null && VerifyPassword(usuario.Contraseña, Contraseña))
            {
                // Configurar la sesión con los datos del usuario
                Session["UsuarioActual"] = usuario;
                Session["UsuarioId"] = usuario.Id;
                Session["UsuarioNombre"] = usuario.Nombre;

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid username or password.");
            return View();
        }


        [HttpGet]
        public ActionResult Register()
        {
            var roles = db.Roles1.Where(r => r.Nombre != "Administrador")
                                .Select(r => new { r.Id, r.Nombre })
                                .ToList();

            ViewBag.Roles = new SelectList(roles, "Id", "Nombre");
            return View();
        }

        [HttpPost]
        public ActionResult Register(string Usuario1, string Contraseña, string Nombre, int RolId)
        {
            if (string.IsNullOrEmpty(Usuario1) || string.IsNullOrEmpty(Contraseña) || string.IsNullOrEmpty(Nombre))
            {
                ModelState.AddModelError("", "All fields are required.");
                return View();
            }

            if (db.Usuarios1.Any(u => u.Usuario1 == Usuario1))
            {
                ModelState.AddModelError("", "The username is already taken.");
                return View();
            }

            var newUser = new Usuarios
            {
                Usuario1 = Usuario1,
                Contraseña = HashPassword(Contraseña),
                Nombre = Nombre,
                RolId = RolId
            };

            db.Usuarios1.Add(newUser);
            db.SaveChanges();

            return RedirectToAction("Login", "Auth");
        }


        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Auth");
        }
    }
}
