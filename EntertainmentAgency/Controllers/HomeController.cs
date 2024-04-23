using EntertainmentAgency.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EntertainmentAgency.Controllers
{
    public class HomeController : Controller
    {
        private IDataRepo _repo;

        public HomeController(IDataRepo repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EntertainerList()
        {
            var ents = _repo.Entertainers;
            return View(ents);
        }

        [HttpGet]
        public IActionResult NewEnt()
        {
            return View("Edit", new Entertainer());
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var ent = _repo.GetEntById(id);
            return View(ent);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ent = _repo.GetEntById(id);
            return View(ent);
        }

        [HttpPost]
        public IActionResult NewEnt(Entertainer ent)
        {
            if(ModelState.IsValid)
            {
                DateTime datetime = DateTime.Now;
                DateOnly dateonly = DateOnly.FromDateTime(datetime);
                ent.DateEntered = dateonly;
                _repo.AddEnt(ent);
                return RedirectToAction("EntertainerList");
            }
            else
            {
                return View(ent);
            }
        }

        [HttpPost]
        public IActionResult Edit(Entertainer ent)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateEnt(ent);
                return RedirectToAction("EntertainerList");
            }
            else
            {
                return View(ent);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var ent = _repo.GetEntById(id);
            return View(ent);
        }

        [HttpPost]
        public IActionResult Delete(Entertainer ent)
        {
            _repo.DeleteEnt(ent);
            return RedirectToAction("EntertainerList");
        }
    }
}
