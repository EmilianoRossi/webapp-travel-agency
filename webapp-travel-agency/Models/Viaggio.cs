using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Models
{
    public class Viaggio
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(15, ErrorMessage = "Il nome deve essere di massimo 15 caratteri")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Il prezzo è obbligatorio")]
        public double Prezzo { get; set; }
        [Required(ErrorMessage = "descrizione è obbligatorio")]
        public string Descrizione { get; set; }
        [Required(ErrorMessage = " Il link della foto è obbligatorio")]
        [Url(ErrorMessage = "Devi inserire un Url")]
        public string Foto { get; set; }
        public Viaggio()
        {



        }

        public Viaggio(string nome, double prezzo, string descrizione, string foto)
        {

            this.Nome = nome;
            this.Prezzo = prezzo;
            this.Descrizione = descrizione;
            this.Foto = foto;

        }

    }
}
