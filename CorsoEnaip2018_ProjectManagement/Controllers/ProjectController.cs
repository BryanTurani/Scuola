using CorsoEnaip2018_ProjectManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsoEnaip2018_ProjectManagement.Controllers
{
    public class ProjectController : Controller
    {
        private readonly static List<Project> Models
            = new List<Project>
            {
                new Project(1, "Bryan", "Carlotta", "Massimiliano", 2005, 01, 01, 2006, 12, 31, 2006, 01, 01, 200000, 250000),
                new Project(2, "Marzio", "Marzia", "Massimiliano", 2005, 01, 01, 2006, 12, 31, 2006, 01, 01, 100000, 120000),
                new Project(3, "Andrea", "Nicole", "Massimiliano", 2005, 01, 01, 2006, 12, 31, 2006, 01, 01, 50000, 70000),
            };

        public ViewResult Index()
        {
            return View(Models);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = Models.FirstOrDefault(x => x.Id == id);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Project model)
        {
            var index = Models.FindIndex(x => x.Id == model.Id);

            if (index == -1)
                return NotFound();

            Models[index] = model;

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = Models.FirstOrDefault(x => x.Id == id);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Project model)
        {
            var index = Models.FindIndex(x => x.Id == model.Id);

            if (index == -1)
                return NotFound();

            Models.RemoveAt(index);

            return RedirectToAction(nameof(Index));
        }
    }
}
