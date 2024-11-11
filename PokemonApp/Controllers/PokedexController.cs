using PokemonApp.Models;
using System.Linq;
using System.Web.Mvc;

namespace PokemonApp.Controllers
{
    public class PokedexController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // Listar todos los Pokémon
        public ActionResult Index()
        {
            var pokemons = db.Pokemons.ToList();
            return View(pokemons);
        }

        // Detalles de un Pokémon
        public ActionResult Details(int id)
        {
            var pokemon = db.Pokemons.Find(id);
            if (pokemon == null)
            {
                return HttpNotFound();
            }
            return View(pokemon);
        }

        // Crear un nuevo Pokémon (GET)
        public ActionResult Create()
        {
            return View();
        }

        // Crear un nuevo Pokémon (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pokemon pokemon)
        {
            if (ModelState.IsValid)
            {
                db.Pokemons.Add(pokemon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pokemon);
        }

        // Editar un Pokémon (GET)
        public ActionResult Edit(int id)
        {
            var pokemon = db.Pokemons.Find(id);
            if (pokemon == null)
            {
                return HttpNotFound();
            }
            return View(pokemon);
        }

        // Editar un Pokémon (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pokemon pokemon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pokemon).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pokemon);
        }

        // Eliminar un Pokémon (GET)
        public ActionResult Delete(int id)
        {
            var pokemon = db.Pokemons.Find(id);
            if (pokemon == null)
            {
                return HttpNotFound();
            }
            return View(pokemon);
        }

        // Eliminar un Pokémon (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var pokemon = db.Pokemons.Find(id);
            db.Pokemons.Remove(pokemon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
