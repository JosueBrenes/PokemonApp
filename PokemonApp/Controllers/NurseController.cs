using PokemonApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PokemonApp.Controllers
{
    public class NurseController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities(); // Conexión a la base de datos
        private static List<NurseRequest> nurseRequests = new List<NurseRequest>();

        public ActionResult Index()
        {
            var nurses = new List<Nurse>
            {
                new Nurse { Name = "Nurse Joy", Age = 30, Region = "Kanto", ExperienceYears = 10 },
                new Nurse { Name = "Nurse Rose", Age = 28, Region = "Johto", ExperienceYears = 8 },
                new Nurse { Name = "Nurse Lily", Age = 35, Region = "Hoenn", ExperienceYears = 12 },
                new Nurse { Name = "Nurse Daisy", Age = 32, Region = "Sinnoh", ExperienceYears = 9 },
                new Nurse { Name = "Nurse Violet", Age = 29, Region = "Unova", ExperienceYears = 7 }
            };

            return View(nurses);
        }

        public ActionResult CreateRequest()
        {
            var model = new CreateRequest
            {
                Pokemons = db.Pokemons.ToList(),
                Nurses = new List<Nurse>
                {
                    new Nurse { Name = "Nurse Joy", Age = 30, Region = "Kanto", ExperienceYears = 10 },
                    new Nurse { Name = "Nurse Rose", Age = 28, Region = "Johto", ExperienceYears = 8 },
                    new Nurse { Name = "Nurse Lily", Age = 35, Region = "Hoenn", ExperienceYears = 12 },
                    new Nurse { Name = "Nurse Daisy", Age = 32, Region = "Sinnoh", ExperienceYears = 9 },
                    new Nurse { Name = "Nurse Violet", Age = 29, Region = "Unova", ExperienceYears = 7 }
                }
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateRequest(CreateRequest model)
        {
            if (ModelState.IsValid)
            {
                var nurseRequest = new NurseRequest
                {
                    Id = nurseRequests.Count + 1,
                    PokemonName = model.PokemonName, 
                    Description = model.Description,
                    AssignedNurse = model.AssignedNurse, 
                    IsAttended = false 
                };

                nurseRequests.Add(nurseRequest);
                return RedirectToAction("Requests");
            }

            model.Pokemons = db.Pokemons.ToList();
            model.Nurses = new List<Nurse>
            {
                new Nurse { Name = "Nurse Joy", Age = 30, Region = "Kanto", ExperienceYears = 10 },
                new Nurse { Name = "Nurse Rose", Age = 28, Region = "Johto", ExperienceYears = 8 },
                new Nurse { Name = "Nurse Lily", Age = 35, Region = "Hoenn", ExperienceYears = 12 },
                new Nurse { Name = "Nurse Daisy", Age = 32, Region = "Sinnoh", ExperienceYears = 9 },
                new Nurse { Name = "Nurse Violet", Age = 29, Region = "Unova", ExperienceYears = 7 }
            };

            return View(model);
        }

        public ActionResult Requests()
        {
            return View(nurseRequests);
        }
    }
}
