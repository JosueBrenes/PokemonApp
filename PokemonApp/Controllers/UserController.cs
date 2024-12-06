using PokemonApp.Models;
using System.Linq;
using System.Web.Mvc;

namespace PokemonApp.Controllers
{
    public class UserController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // Listar todos los usuarios
        public ActionResult Index()
        {
            var usuarios = db.Usuarios1.ToList();
            return View(usuarios);
        }

        // Detalles de un usuario
        public ActionResult Details(int id)
        {
            var usuario = db.Usuarios1.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // Crear un nuevo usuario (GET)
        public ActionResult Create()
        {
            ViewBag.Roles = new SelectList(db.Roles1.ToList(), "Id", "Nombre");
            return View();
        }

        // Crear un nuevo usuario (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios1.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Recargar los roles si ocurre un error
            ViewBag.Roles = db.Roles1
                              .Select(r => new SelectListItem
                              {
                                  Value = r.Id.ToString(),
                                  Text = r.Nombre
                              })
                              .ToList();
            return View(usuario);
        }

        // Editar un usuario (GET)
        public ActionResult Edit(int id)
        {
            var usuario = db.Usuarios1.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }

            ViewBag.Roles = new SelectList(db.Roles1.ToList(), "Id", "Nombre", usuario.RolId);
            return View(usuario);
        }

        // Editar un usuario (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Roles = db.Roles1
                              .Select(r => new SelectListItem
                              {
                                  Value = r.Id.ToString(),
                                  Text = r.Nombre
                              })
                              .ToList();

            return View(usuario);
        }

        // Eliminar un usuario (GET)
        public ActionResult Delete(int id)
        {
            var usuario = db.Usuarios1.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // Eliminar un usuario (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var usuario = db.Usuarios1.Find(id);
            db.Usuarios1.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
