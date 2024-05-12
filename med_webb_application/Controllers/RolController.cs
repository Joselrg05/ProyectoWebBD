using med_webb_CapaDato.Modelado;
using med_webb_capa_negocio;
using System;
using System.Web.ApplicationServices;
using System.Web.Mvc;

namespace web_application_med_webb.Controllers
{
    public class RolController : Controller
    {
        private med_webb_database db;
        private rol_services rolService;


        public RolController()
        {
            db = new med_webb_database();
            rolService = new rol_services(db);
        }

        // GET: Rol
        public ActionResult Index()
        {
            var listaRol =  rolService.GetAll();

            return View(listaRol);
        }

        [HttpPost]
        public ActionResult Crear(Rol roles)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(roles);
                }

                var errorMensaje = rolService.ValidarAntesCrear(roles);
                if (string.IsNullOrEmpty(errorMensaje))
                {
                    if (rolService.Create(roles))
                        return RedirectToAction("Index");

                    ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador";
                    return View(roles);
                }

                ViewBag.ErrorMensaje = errorMensaje;
                return View(roles);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador" + ex;
                return View(roles);
            }
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var objRol = rolService.BuscarId(id);

            if (objRol == null)
                return RedirectToAction("Index");

            return View(objRol);
        }

        [HttpPost]
        public ActionResult Editar(Rol roles)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(roles);
                }

                var errorMensaje = rolService.ValidarAntesActualizar(roles);
                if (string.IsNullOrEmpty(errorMensaje))
                {
                    rolService.Update(roles);
                    return RedirectToAction("Index");
                }

                ViewBag.ErrorMensaje = errorMensaje;
                return View(roles);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador" + ex;
                return View(roles);
            }
        }


        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            var objRol = rolService.BuscarId(id);

            if (objRol == null)
                return RedirectToAction("Index");

            return View(objRol);
        }

        [HttpPost]
        public ActionResult Eliminar(Rol roles)
        {
            try
            {
                var errorMensaje = rolService.ValidarAntesEliminar((int)roles.Id);
                if (string.IsNullOrEmpty(errorMensaje))
                {
                    if (rolService.Delete((int)roles.Id))
                        return RedirectToAction("Index");

                    ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador";
                    return View(roles);
                }

                ViewBag.ErrorMensaje = errorMensaje;
                return View(roles);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador" + ex;
                return View(roles);
            }
        }
    }
}