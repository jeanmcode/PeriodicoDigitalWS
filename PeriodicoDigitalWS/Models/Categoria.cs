using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PeriodicoDigitalWS.Models
{
    [Table("Categorias", Schema = "dbo")]
    public class Categoria
    {


        public Categoria()
        {

            this.Noticias = new HashSet<Noticia>();

        }


        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Código")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "El código debe de ser de 3 caracteres")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public virtual ICollection<Noticia> Noticias { get; set; }


    }
}