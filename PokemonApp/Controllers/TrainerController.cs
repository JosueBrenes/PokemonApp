using PokemonApp.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PokemonApp.Controllers
{
    public class TrainerController : Controller
    {
        public ActionResult Index()
        {
            var trainers = new List<Trainer>
            {
                new Trainer
                {
                    Name = "Ash Ketchum",
                    Age = 16,
                    Region = "Kanto",
                    Badges = 8
                },
                new Trainer
                {
                    Name = "Misty",
                    Age = 17,
                    Region = "Kanto",
                    Badges = 5
                },
                new Trainer
                {
                    Name = "Brock",
                    Age = 18,
                    Region = "Kanto",
                    Badges = 6
                },
                new Trainer
                {
                    Name = "Gary Oak",
                    Age = 16,
                    Region = "Kanto",
                    Badges = 10
                },
                new Trainer
                {
                    Name = "Serena",
                    Age = 15,
                    Region = "Kalos",
                    Badges = 3
                },
                new Trainer
                {
                    Name = "Dawn",
                    Age = 14,
                    Region = "Sinnoh",
                    Badges = 4
                }
            };

            return View(trainers);
        }
    }
}
