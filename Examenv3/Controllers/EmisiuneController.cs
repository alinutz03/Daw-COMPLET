using Examenv3.ContextModels;
using Examenv3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Examenv3.Controllers
{
    public class EmisiuneController : Controller
    {
        private readonly EmisiuneContext _context;
        public EmisiuneController(EmisiuneContext ctx)
        {
            _context = ctx;
        }

        public IActionResult Index()
        {
            ViewBag.NumarTotalEmisiuni = NumarTotalEmisiuni();
            var Emisiune = _context.Emisiuni.Include(c => c.CanalTV).ToList();

            return View(Emisiune);
        }

        // Numarare 
        public int NumarTotalEmisiuni()
        {
            return _context.Emisiuni.Count();
        }

    


     
        // DESc an lansare

        public IActionResult AfisareDesc()
        {
            var Emisiuni = _context.Emisiuni.Include(c => c.CanalTV).OrderByDescending(c => c.AnulLansarii).ToList();

            return View(Emisiuni);
        }

        public IActionResult CanalNumeAlfabetic()
        {
            // Alfabetic
            var Emisiuni = _context.Emisiuni.Include(c => c.CanalTV).OrderBy(c => c.CanalTV.Nume).ToList();
            // In ordine invers alfabetica se foloseste OrderByDescendin
            return View(Emisiuni);
        }




        public IActionResult GetAdaugareEmisiune()
        {
            ViewBag.CanalTV = _context.CanaleTV.Select(x => new SelectListItem { Text = x.Nume, Value = x.Id.ToString() }).ToList(); // Trebuia oare si AdresaSediu ????
            //ViewBag.CanalTV = _context.CanaleTV.OrderBy(f => f.Nume).ToList();
            return View("AdaugaEmisiune");
        }


        [HttpPost]
        public IActionResult PostAdaugareEmisiune(EMISIUNE emisiune)
        {
            {
                _context.Add(emisiune);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult EditeazaEmisiune(int id) //Iii trimitem Id ul stirii ca parametru in url 
        {
            var emisiune = _context.Emisiuni.Find(id); //Cautam stirea dupa id
            ViewBag.CanalTV = _context.CanaleTV.Select(x => new SelectListItem { Text = x.Nume, Value = x.Id.ToString() }).ToList(); //populam lista de categorii din formular
            return View(emisiune); //trimitem stirea pe care o modificam catre view
        }
        [HttpPost]
        public IActionResult EditeazaEmisiune(EMISIUNE emisiune)
        {
            {
                _context.Emisiuni.Update(emisiune);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult StergeEmisiune(int id) //Iii trimitem Id ul stirii ca parametru in url 
        {
            var stire = _context.Emisiuni.Find(id); //Cautam stirea dupa id
            _context.Emisiuni.Remove(stire);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult CautaCanale(string Producator)
        {
            ViewBag.Emisiune = _context.Emisiuni
                .Include(emisiune => emisiune.CanalTV)
                .Where(emisiune => emisiune.Producator == Producator)
                .Select(emisiune => emisiune.CanalTV)
                .Distinct()
                .ToList();

            ViewBag.Producator = _context.Emisiuni.Select(emisiune =>
            new SelectListItem
            {
                Value = emisiune.Producator,
                Text = emisiune.Producator
            }
            ).Distinct().ToList();
            return View("CautaCanale");
        }

        public IActionResult CautaCanale()
        {
            ViewBag.Producator = _context.Emisiuni.Select(emisiune =>
            new SelectListItem
            {
                Value = emisiune.Producator,
                Text = emisiune.Producator
            }
            ).Distinct().ToList();
            return View("CautaCanale");
        }
    }
}
