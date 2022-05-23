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

        [HttpGet]
        public IActionResult Modifica(int id)
        {
            Viaggio viaggioDaModificare = null;

            using (ViaggioContext db = new ViaggioContext())
            {
                viaggioDaModificare = db.Viaggios
                     .Where(viaggio => viaggio.Id == id)
                     .FirstOrDefault();

            }

            if (viaggioDaModificare == null)
            {
                return NotFound();
            }
            else
            {
                return View("Modifica", viaggioDaModificare);
            }

        }

        [HttpPost]
        public IActionResult Modifica(int id, Viaggio model)
        {
            if (!ModelState.IsValid)
            {
                return View("Modifica", model);
            }

            Viaggio viaggioDaModificare = null;

            using (ViaggioContext db = new ViaggioContext())
            {
                viaggioDaModificare = db.Viaggios
                     .Where(viaggio => viaggio.Id == id)
                     .FirstOrDefault();


                if (viaggioDaModificare != null)
                {
                    viaggioDaModificare.Nome = model.Nome;
                    viaggioDaModificare.Descrizione = model.Descrizione;
                    viaggioDaModificare.Foto = model.Foto;
                    viaggioDaModificare.Prezzo = model.Prezzo;

                    db.SaveChanges();

                    return RedirectToAction("HomePage");
                }
                else
                {
                    return NotFound();
                }
            }

            
        }

        [HttpPost]
        public IActionResult Cancella(int id)
        {

            using (ViaggioContext db = new ViaggioContext())
            {
                Viaggio viaggioDaCancellare = db.Viaggios
                     .Where(viaggio => viaggio.Id == id)
                     .FirstOrDefault();

                if (viaggioDaCancellare != null)
                {
                    db.Viaggios.Remove(viaggioDaCancellare);
                    db.SaveChanges();

                    return RedirectToAction("HomePage", "Viaggi");
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }

    

}
