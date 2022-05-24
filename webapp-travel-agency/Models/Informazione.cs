using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Models
{
    public class Informazione
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(75, ErrorMessage = "Il titolo della categoria non puo superare i 75 caratteri")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(75, ErrorMessage = "Il titolo della categoria non puo superare i 75 caratteri")]
        public string Cognome { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(75, ErrorMessage = "Il titolo della categoria non puo superare i 75 caratteri")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(75, ErrorMessage = "Il titolo della categoria non puo superare i 75 caratteri")]
        public int Telefono { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(75, ErrorMessage = "Il titolo della categoria non puo superare i 75 caratteri")]
        public string Testo { get; set; }
        //metodo per collegare un entità in relazione 1 n
        public int? ViaggioId { get; set; }
        public Viaggio? Viaggio { get; set; }

        public Informazione()
        {



        }
        public Informazione(string nome , string cognome , string email , int telefono , string testo)
        {

            this.Nome = nome;
            this.Cognome = cognome;
            this.Telefono = telefono;
            this.Email = email;
            this.Testo = testo;

        }

    }
}
