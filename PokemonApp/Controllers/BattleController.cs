using System.Linq;
using System.Web.Mvc;
using PokemonApp.Models;

public class BattleController : Controller
{
    private DatabaseEntities db = new DatabaseEntities();

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

        var battle = new Battle { Pokemon1 = pokemon1, Pokemon2 = pokemon2 };
        var result = battle.StartBattle();

        ViewBag.Result = result;
        return View("BattleResult");
    }
}
