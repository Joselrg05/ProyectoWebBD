using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using med_webb_CapaDato.Modelado;
using System.Web.Mvc;
using med_webb_CapaNegocio;
using med_webb_capa_negocio;

namespace med_webb_application.Controllers
{
    public class RolController : Controller
    {
        private Med_Webb_Database db;
        private rol_services rol_Services;

        public RolController()
        {
            db = new Med_Webb_Database();
            rol_Services = new rol_services(db);
        }

        // GET: Pedido
        public ActionResult Index()
        {
            var listarol = rol_Services.GetAll();

            return View(listarol);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Role rol)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(rol);
                }

                var errorMensaje = rol_Services.ValidarAntesCrear(rol);
                if (string.IsNullOrEmpty(errorMensaje))
                {
                    if (rol_Services.Create(rol))
                        return RedirectToAction("Index");

                    ViewBag.ErrorMensaje = "Error servidor, Contactar al administrador";
                    return View(rol);
                }

                ViewBag.ErrorMensaje = errorMensaje;
                return View(rol);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMensaje = "Error servidor, Contactar al administrador" + ex;
                return View(rol);
            }
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var objrol = rol_Services.BuscarId(id);
            if (objrol == null)
                return RedirectToAction("index");

            return View(objrol);
        }

        [HttpPost]
        public ActionResult Editar(Role rol)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(rol);
                }

                var errorMenssage = rol_Services.ValidarAntesActualizar(rol);
                if (string.IsNullOrEmpty(errorMenssage))
                {
                    rol_Services.Update(rol);
                    return RedirectToAction("index");
                }

                ViewBag.ErrorMensaje = errorMenssage;
                return View(rol);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador" + ex;
                return View(rol);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            var rol = rol_Services.BuscarId(id);

            if (rol == null)
                return RedirectToAction("Index");

            return View(rol);
        }

        [HttpPost]
        public ActionResult Eliminar(Role rol)
        {
            try
            {
                var errorMensaje = rol_Services.ValidarAntesEliminar(rol.Id);
                if (string.IsNullOrEmpty(errorMensaje))
                {
                    if (rol_Services.Delete(rol.Id))
                        return RedirectToAction("Index");

                    ViewBag.ErrorMensaje = "Error servidor, Contactar al administrador";
                    return View(rol);
                }

                ViewBag.ErrorMensaje = errorMensaje;
                return View(rol); 
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMensaje = "Error servidor, Contactar al administrador" + ex;
                return View(rol);
            }
        }
    }
}