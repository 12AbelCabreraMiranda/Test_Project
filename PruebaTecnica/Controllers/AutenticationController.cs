using PruebaTecnica.Models;
using PruebaTecnica.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PruebaTecnica.Controllers
{
    public class AutenticationController : Controller
    {
        private readonly string rolAdmin = "Administrador";
        private readonly string rolEmpleado = "Empleado";

        //Inyeccion
        private readonly PruebaTecnicaContext ctx;
        public AutenticationController()
        {
            ctx = new PruebaTecnicaContext();
        }

        //Consulta de datos de usuarios
        public async Task<ActionResult> DatosUsuarios()
        {
            var session = Session["User"];
            //Si no hay sesión, retornarlo al Index(Login)
            if (session == null)
            {
                return RedirectToAction("Index");//Redirecciona al Index del Controller Login
            }
            //PERMITE MOSTRAR LOS DATOS DE LOS USUARIOS CON ESTADO=1 EN TABLA
            var Usu = await ctx.Usuarios.Where(x => x.Estado == "1").Include(x => x.Empleado).ToListAsync();
            return View(Usu);
        }


        // GET: Autentication
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            if (model != null)
            {
                using (var context = new PruebaTecnicaContext())
                {
                    var user = context.Usuarios
                                      .Where(x => x.NombreUsuario == model.UserName && x.ContraseniaUsuario == model.UserPassword && x.Estado=="1")
                                      .FirstOrDefault();

                    if (user != null)
                    {
                        var rol = context.TipoUsuario.FirstOrDefault(x => x.TipoUsuarioId == user.TipoUsuarioId);
                        if (rol != null)
                        {
                            //Session["User"] = $"{user.NombreUsuario} {user.Apellido}";
                            Session["User"] = $"{user.NombreUsuario}";
                            Session["Rol"] = rol.NombreTipo;

                            if (rol.NombreTipo.Equals("Administrador"))
                            {
                                return Redirect("/Autentication/Admin");
                            }
                            else
                            {
                                return Redirect("/Autentication/Empleado");
                            }
                        }
                    }
                    else
                        return View(model);
                }
            }
            return View(model);
        }

        //MÉTODO ADMINISTRADOR
        public ActionResult Admin()
        {
            var session = Session["User"];
            //Si no hay sesión, retornarlo al Index(Login)
            if (session == null)
            {
                return RedirectToAction("Index");//Redirecciona al Index del Controller Login
            }

            //Si hay sesión autenticarlo!
            if (Session["Rol"].ToString().Equals(this.rolAdmin))
            {
                ViewBag.User = Session["User"];
                return View();
            }
            else
            {
                return RedirectToAction("Empleado");
            }
        }

        //METODO EMPLEADO
        public ActionResult Empleado()
        {
            var session = Session["User"];
            if (session == null)
            {
                return RedirectToAction("Index");//Redirecciona al Index del Controller Login
            }

            if (Session["Rol"].ToString().Equals(this.rolEmpleado))
            {
                ViewBag.User = Session["User"];
                return View();
            }
            else
            {
                return RedirectToAction("Admin");
            }
        }

        //MÉTODO CERRAR SESIÓN
        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Index");
        }





    }
}