using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.WEB.Models;
using Restaurant.Datos;

namespace Restaurant.WEB.Controllers
{
    public class CuentaController : Controller
    {

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                string password = Seguridad.Encriptar(model.Password);
                using (var var = new RestaurantEntities())
                {

                    //var result = var.USUARIO.FirstOrDefault(n => n.NOMBRE_USUARIO == model.Username && n.PASSWORD == model.Password);
                    var resultado = var.USUARIO.Where(n => n.NOMBRE_USUARIO == model.Username && n.PASSWORD == password).FirstOrDefault();

                    if (resultado != null)
                    {
                        return this.RedirectToAction("Index", "Cuenta");
                    }
                    else
                    {
                        this.ModelState.AddModelError(string.Empty, "Error al loguearse");
                        return this.View(model);

                    }

                }
            }
            else
            {
                this.ModelState.AddModelError(string.Empty, "Failed to login.");
                return this.View(model);
            }

        }

        // GET: Login
        public ActionResult Index()
        {


            using (var var = new RestaurantEntities())
            {
                return View(var.ROL.ToList());
            }
        }

        public ActionResult Usuarios()
        {


            using (var var = new RestaurantEntities())
            {
                return View(var.USUARIO.ToList());
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {

            using (var var = new RestaurantEntities())
            {

                var.USUARIO.Add(RegisterToUsuario(model));
                var.SaveChanges();
                return View();
            }
        }

        public USUARIO RegisterToUsuario(RegisterViewModel model)
        {
            USUARIO user = new USUARIO();
            user.ID_USUARIO = 5;
            user.EMAIL_USUARIO = model.Email;
            user.NOMBRE_USUARIO = model.NombreUsuario;
            user.PASSWORD = Seguridad.Encriptar(model.Password);
            user.ROL_ID_ROL = 1;
            user.RUT_USUARIO = model.Rut;

            return user;
        }
    }
}