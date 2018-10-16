using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PublicacionApi.Models
{
    public class MiPublicacionContext : DbContext
    {
        public MiPublicacionContext() : base("MiPublicacionConnection")
        {

        }

        public DbSet<Publicacion> Publicacions { get; set; }
    }
}