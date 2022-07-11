using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PeriodicoDigitalWS.Models
{
    [Table("Autores", Schema = "dbo")]
    public class Autor
    {

        public Autor()
        {

            this.Noticias = new HashSet<Noticia>();

        }


        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Codigo")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "El código debe de ser de 3 caracteres")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        public virtual ICollection<Noticia> Noticias { get; set; }

    }
}