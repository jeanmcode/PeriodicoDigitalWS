using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PeriodicoDigitalWS.Models
{
    [Table("Noticias", Schema = "dbo")]
    public class Noticia
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Codigo")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "El código debe de ser de 3 caracteres")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }

        [Display(Name = "Imagen")]
        public byte[] Imagen { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Cuerpo")]
        public string Cuerpo { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }

        //Foreing key
        public int CategoriaId { get; set; }

        public int AutorId { get; set; }



        //relacionar padre con el hijo
        public virtual Categoria categoria { get; set; }

        //relacionar padre con el hijo
        public virtual Autor autor { get; set; }




    }
}