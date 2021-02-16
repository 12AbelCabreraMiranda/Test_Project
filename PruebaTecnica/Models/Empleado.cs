using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PruebaTecnica.Models
{
    [Table("Empleado")]
    public class Empleado
    {
        [Key]
        public int EmpleadoId { get; set; }

        [Required, MaxLength(50)]
        public string NombreEmpleado { get; set; }

        [Required]
        public string Direccion { get; set; }

        //RELACION
        public List<Usuarios> Usuarios { get; set; }
    }
}