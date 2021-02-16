using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PruebaTecnica.Models
{
    [Table("TipoUsuario")]
    public class TipoUsuario
    {
        [Key]
        public int TipoUsuarioId { get; set; }

        public string NombreTipo { get; set; }

        //RELACION
        public List<Usuarios> Usuarios { get; set; }
    }
}