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

        [HttpGet]
        public IActionResult ListaViaggi()
        {

            List<Viaggio> listaViaggi = new List<Viaggio>();

            using(ViaggioContext db = new ViaggioContext())
            {

                listaViaggi = db.Viaggios.ToList<Viaggio>();

            }
            return View("ListaViaggi", listaViaggi);

        }

        [HttpGet]
        public IActionResult Dettagli(int id)
        {

            using (ViaggioContext db = new ViaggioContext())
            {
                try { 
                
                    Viaggio viaggioTrovato = db.Viaggios
                         .Where(viaggio => viaggio.Id == id)
                         .First();

                    return View("Dettagli", viaggioTrovato);

                }
                catch (InvalidOperationException ex)
                {
                    return NotFound("Il pacchetto con id " + id + " non è stato trovato");
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }

        }
    }

    

}
