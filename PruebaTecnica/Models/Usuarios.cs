using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PruebaTecnica.Models
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        public int UsuariosId { get; set; }

        [Required, MaxLength(50)]
        public string NombreUsuario { get; set; }

        [Required, MaxLength(225)]
        public string ContraseniaUsuario { get; set; }

        [Required, MaxLength(50)]
        public string Estado { get; set; }



        //RELACIONES   -- Extraer IDs de los dos Modelos
        //Model 1: Empleados
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }

        //Model 2: TipoUsuario
        public int TipoUsuarioId { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}