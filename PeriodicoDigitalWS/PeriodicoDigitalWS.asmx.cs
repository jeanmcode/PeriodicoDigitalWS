using PeriodicoDigitalWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PeriodicoDigitalWS
{
    /// <summary>
    /// Descripción breve de PeriodicoDigitalWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class PeriodicoDigitalWS : System.Web.Services.WebService
    {

        ApplicationDbContext db = new ApplicationDbContext();


        [WebMethod]
        public List<NoticiaWS> GetNoticiasByCategoria(int Id)
        {

            return db.Noticias.Where(x => x.CategoriaId == Id).Select(

                x => new NoticiaWS()
                {

                    codigo = x.Codigo,
                    Titulo = x.Titulo,
                    Imagen = x.Imagen,
                    Cuerpo = x.Cuerpo,
                    Fecha = x.Fecha,
                    AutorId = x.AutorId,
                    CategoriaId = x.CategoriaId




                }).ToList();



        }

        [WebMethod]
        public bool SetNoticias(string codigo, string titulo, byte[] imagen, string cuerpo, DateTime fecha, int AutorId, int CategoriaId)
        {

            Noticia noticia = new Noticia();

            noticia.Codigo = codigo;
            noticia.Titulo = titulo;
            noticia.Imagen = imagen;
            noticia.Cuerpo = cuerpo;
            noticia.Fecha = fecha;
            noticia.AutorId = AutorId;
            noticia.CategoriaId = CategoriaId;

            db.Noticias.Add(noticia);

            if (db.SaveChanges() > 0)
            {
                return true;
            }

            else { return false; }

        }

        //Regresa las noticias de todas las categorias dada una fecha 
        [WebMethod]
        public List<NoticiaWS> GetNoticiasByFecha(DateTime Fecha)
        {


            return db.Noticias.Where(x => x.Fecha == Fecha).Select(



                x => new NoticiaWS()

                {

                    codigo = x.Codigo,
                    Titulo = x.Titulo,
                    Imagen = x.Imagen,
                    Cuerpo = x.Cuerpo,
                    Fecha = x.Fecha,
                    AutorId = x.AutorId,
                    CategoriaId = x.CategoriaId

                }).ToList();


        }

        //Regresa todas las categorias
        [WebMethod]
        public List<CategoriaWS> GetCategoria()
        {


            return db.Categorias.Where(x => x.Id != null).Select(

                x => new CategoriaWS()
                {

                    Codigo = x.Codigo,
                    Descripcion = x.Descripcion




                }



         ).ToList();

        }







        //Clases de acceso(Seriabilizacion)
        public class CategoriaWS
        {

            public int Id { get; set; }

            public string Codigo { get; set; }


            public string Descripcion { get; set; }

        }

        public class NoticiaWS
        {


            public int Id { get; set; }


            public string codigo { get; set; }


            public string Titulo { get; set; }


            public byte[] Imagen { get; set; }


            public string Cuerpo { get; set; }


            public DateTime Fecha { get; set; }

            //Foreing key
            public int CategoriaId { get; set; }

            public int AutorId { get; set; }




        }

        public class AutorWS
        {

            public int Id { get; set; }


            public string codigo { get; set; }


            public string Nombre { get; set; }

        }
    }
}
