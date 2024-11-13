using System.Linq;
using System.Web.Mvc;
using PokemonApp.Models;

public class BattleController : Controller
{
    private DatabaseEntities db = new DatabaseEntities();
    private static Battle currentBattle;

    public ActionResult Index()
    {
        var pokemons = db.Pokemons.ToList();
        return View(pokemons);
    }

    [HttpPost]
    public ActionResult StartBattle(int pokemon1Id, int pokemon2Id)
    {
        var pokemon1 = db.Pokemons.Find(pokemon1Id);
        var pokemon2 = db.Pokemons.Find(pokemon2Id);

        if (pokemon1 == null || pokemon2 == null)
        {
            return HttpNotFound("One or both Pokémon not found.");
        }

        currentBattle = new Battle { Pokemon1 = pokemon1, Pokemon2 = pokemon2 };
        return RedirectToAction("Round");
    }

    public ActionResult Round()
    {
        if (currentBattle == null)
        {
            return RedirectToAction("Index");
        }

        ViewBag.Pokemon1Health = currentBattle.Pokemon1Health;
        ViewBag.Pokemon2Health = currentBattle.Pokemon2Health;
        ViewBag.Pokemon1Name = currentBattle.Pokemon1.Nombre;
        ViewBag.Pokemon2Name = currentBattle.Pokemon2.Nombre;

        return View();
    }

    [HttpPost]
    public ActionResult PlayRound()
    {
        if (currentBattle == null)
        {
            return RedirectToAction("Index");
        }

        ViewBag.Result = currentBattle.StartRound();

        if (currentBattle.IsBattleOver())
        {
            string winner = currentBattle.Pokemon1Health > 0 ? currentBattle.Pokemon1.Nombre : currentBattle.Pokemon2.Nombre;
            return RedirectToAction("BattleOver", new { winner });
        }

        return RedirectToAction("Round");
    }

    public ActionResult BattleOver(string winner)
    {
        ViewBag.Winner = winner;
        return View();
    }
}
