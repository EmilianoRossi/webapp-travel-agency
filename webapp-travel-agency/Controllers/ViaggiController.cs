using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Data;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    public class ViaggiController : Controller
    {
        public IActionResult HomePage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("FormPost");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Viaggio nuovoViaggio)
        {
            if (!ModelState.IsValid)
            {
                return View("FormPost", nuovoViaggio);
            }

            using (ViaggioContext db = new ViaggioContext())
            {
                Viaggio viaggioDaCreare = new Viaggio(nuovoViaggio.Nome, nuovoViaggio.Prezzo, nuovoViaggio.Descrizione, nuovoViaggio.Foto);

                db.Viaggios.Add(viaggioDaCreare);
                db.SaveChanges();
            }

            return RedirectToAction("HomePage");
        }

        public IActionResult ListaViaggi()
        {

            List<Viaggio> listaViaggi = new List<Viaggio>();

            using(ViaggioContext db = new ViaggioContext())
            {

                listaViaggi = db.Viaggios.ToList<Viaggio>();

            }
            return View("ListaViaggi", listaViaggi);

        }
    }

}
