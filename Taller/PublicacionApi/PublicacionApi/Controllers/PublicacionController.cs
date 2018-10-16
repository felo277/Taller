using PublicacionApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PublicacionApi.Controllers
{
    public class PublicacionController : ApiController
    {
        //Listar Todo
        [HttpGet]
      public IEnumerable<Publicacion> Get()
        {
            using (var context = new MiPublicacionContext())
            {
                return context.Publicacions.ToList();
            }
        }

        // Listar 1 solo 
        [HttpGet]
        public Publicacion Get(int id)
        {
            using (var context = new MiPublicacionContext())
            {
                return context.Publicacions.FirstOrDefault(x=> x.Id == id);
            }
        }

        //Insertar
        [HttpPost]
        public IHttpActionResult Post(Publicacion publicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var context = new MiPublicacionContext())
            {
                context.Publicacions.Add(publicacion);
                context.SaveChanges();
                return Ok(publicacion);
            }
        }

        //Actualizar
        [HttpPut]
        public Publicacion Put(Publicacion publicacion)
        {
            using (var context = new MiPublicacionContext())
            {
                var publicacionAct = context.Publicacions.FirstOrDefault(x => x.Id == publicacion.Id);
                publicacionAct.Usuario = publicacion.Usuario;
                publicacionAct.Descripcion = publicacion.Descripcion;
                publicacionAct.FechaPublicacion = publicacion.FechaPublicacion;
                publicacionAct.MeGusta = publicacion.MeGusta;
                publicacionAct.MeDisgusta = publicacion.MeDisgusta;
                publicacionAct.VecesCompartido = publicacion.VecesCompartido;
                publicacionAct.EsPrivada = publicacion.EsPrivada;                                               
                context.SaveChanges();
                return publicacion;
            }


        }

        //Eliminar
        [HttpDelete]
        public bool Delete(int id)
        {
            using (var context = new MiPublicacionContext())
            {
                var publicacionDel = context.Publicacions.FirstOrDefault(x => x.Id == id);
                context.Publicacions.Remove(publicacionDel);
                context.SaveChanges();
                return true;
            }


        }

    }
}
