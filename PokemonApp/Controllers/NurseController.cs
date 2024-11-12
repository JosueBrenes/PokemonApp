using PokemonApp.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PokemonApp.Controllers
{
    public class NurseController : Controller
    {
        public ActionResult Index()
        {
            var nurses = new List<Nurse>
            {
                new Nurse
                {
                    Name = "Nurse Joy",
                    Age = 30,
                    Region = "Kanto",
                    ExperienceYears = 10
                },
                new Nurse
                {
                    Name = "Nurse Rose",
                    Age = 28,
                    Region = "Johto",
                    ExperienceYears = 8
                },
                new Nurse
                {
                    Name = "Nurse Lily",
                    Age = 35,
                    Region = "Hoenn",
                    ExperienceYears = 12
                },
                new Nurse
                {
                    Name = "Nurse Daisy",
                    Age = 32,
                    Region = "Sinnoh",
                    ExperienceYears = 9
                },
                new Nurse
                {
                    Name = "Nurse Violet",
                    Age = 29,
                    Region = "Unova",
                    ExperienceYears = 7
                }
            };

            return View(nurses);
        }
    }
}
