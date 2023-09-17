using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MotoGP.Data;
using MotoGP.Models;
using MotoGP.Models.ViewModels;

namespace MotoGP.Controllers
{
    public class InfoController : Controller
    {
        private readonly GPContext _context;

        public InfoController(GPContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListRaces()
        {
            ViewData["BannerNr"] = 0;
            ViewData["Title"] = "Races";
            var races = _context.Races.OrderBy(r => r.Date);
            return View(races);

        }

        public IActionResult ShowRace(int id)
        {
            var check = id;
            ViewData["BannerNr"] = 0;
            //Race race = _context.Races.Where(r => r.RaceID == RaceID).SingleOrDefault();
            Race race = _context.Races
                            .SingleOrDefault(r => r.RaceID == id);
            ViewData["Title"] = "Race - " + race.Name;
            return View(race);
        }

        public IActionResult SelectRace(int raceID = 0)
        {

            var selectRaceVM = new SelectRaceViewModel();
            if (raceID != 0)
            {
                selectRaceVM.raceID = raceID;
                Race race = _context.Races.Where(r => r.RaceID == raceID).SingleOrDefault();
                selectRaceVM.raceID = race.RaceID;
                selectRaceVM.Name = race.Name;
                selectRaceVM.Description = race.Description;
                selectRaceVM.Country = race.Country;
                selectRaceVM.Length = race.Length;
                selectRaceVM.Date = race.Date;
            }
            ViewData["Title"] = "Races";
            selectRaceVM.Races = new SelectList(_context.Races.OrderBy(r => r.Name), "RaceID", "Name");
            selectRaceVM.raceID = raceID;
            return View(selectRaceVM);
        }

        public IActionResult ListRiders()
        {
            ViewData["BannerNr"] = 1;
            ViewData["Title"] = "Riders";
            var riders = _context.Riders.OrderBy(r => r.Number);
            return View(riders);
        }


        public IActionResult BuildMap()
        {
            Race race1 = new Race { RaceID = 1, X = 517, Y = 19, Name = "Assen" };
            Race race2 = new Race { RaceID = 2, X = 859, Y = 249, Name = "Losail Circuit" };
            Race race3 = new Race { RaceID = 3, X = 194, Y = 428, Name = "Autódromo Termas de Río Hondo" };
            var raceList = new List<Race> { race1, race2, race3 };

            ViewData["RaceList"] = raceList;
            ViewData["Title"] = "Races on map";
            return View();

        }
    }
}
