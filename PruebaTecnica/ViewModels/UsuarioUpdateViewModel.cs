using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaTecnica.ViewModels
{
    public class UsuarioUpdateViewModel
    {
        public int EmpleadoId { get; set; }
        public int UsuariosId { get; set; }
        public string NombreEmpleado { get; set; }
        public string Direccion { get; set; }
        public string NombreUsuario { get; set; }
        public string ContraseniaUsuario { get; set; }
        public int Estado { get; set; }
    }
}