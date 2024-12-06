using PokemonApp.Models;
using System.Linq;
using System.Web.Mvc;

namespace PokemonApp.Controllers
{
    public class RolesController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // Listar todos los roles
        public ActionResult Index()
        {
            var roles = db.Roles1.ToList();
            return View(roles);
        }

        // Detalles de un rol
        public ActionResult Details(int id)
        {
            var role = db.Roles1.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // Crear un nuevo rol (GET)
        public ActionResult Create()
        {
            return View();
        }

        // Crear un nuevo rol (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Roles role)
        {
            if (ModelState.IsValid)
            {
                db.Roles1.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        // Editar un rol (GET)
        public ActionResult Edit(int id)
        {
            var role = db.Roles1.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // Editar un rol (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Roles role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(role).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        // Eliminar un rol (GET)
        public ActionResult Delete(int id)
        {
            var role = db.Roles1.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // Eliminar un rol (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var role = db.Roles1.Find(id);
            db.Roles1.Remove(role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
