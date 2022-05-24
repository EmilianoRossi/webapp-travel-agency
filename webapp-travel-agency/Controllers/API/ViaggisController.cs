using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Models;
using webapp_travel_agency.Data;

namespace webapp_travel_agency.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ViaggisController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get(string? search)
        {
            List<Viaggio> viaggis = new List<Viaggio>();
            using (ViaggioContext db = new ViaggioContext())
            {

                // Ricerca 
                if (search != null && search != "")
                {
                    viaggis = db.Viaggios.Where(viaggi => viaggi.Nome.Contains(search) || viaggi.Descrizione.Contains(search)).ToList<Viaggio>();
                }
                else
                {
                    viaggis = db.Viaggios.ToList<Viaggio>();
                }
            }

            return Ok(viaggis);
        }

        [HttpGet("{id}")]
        public IActionResult DettagliUtente(int id)
        {
            using (ViaggioContext db = new ViaggioContext())
            {
                try
                {

                    Viaggio viaggioTrovato = db.Viaggios
                         .Where(viaggio => viaggio.Id == id)
                         .First();

                    return Ok (viaggioTrovato);

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

        
   


