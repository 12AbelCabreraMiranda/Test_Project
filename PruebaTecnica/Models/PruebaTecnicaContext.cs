using System;
using System.Data.Entity;
using System.Linq;

namespace PruebaTecnica.Models
{
    public class PruebaTecnicaContext : DbContext
    {
        
        public PruebaTecnicaContext()
            : base("name=PruebaTecnicaContext")
        {
        }
        //Modelos de datos
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Empleado> Empleado { get; set; }

    }

   
}