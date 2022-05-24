using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Data;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InformazioniController : Controller
    {
        [HttpPost("{id}")]
        public IActionResult Post([FromBody] Informazione informazioneNuova)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            using (ViaggioContext db = new ViaggioContext())
            {

                db.Add(informazioneNuova);
                db.SaveChanges();
                return Ok();
            }
        }
    }
}
