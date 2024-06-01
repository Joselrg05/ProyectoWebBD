using med_webb_capa_negocio;
using med_webb_CapaDato.Modelado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace med_webb_application.Controllers
{
    public class EmpleadoController : Controller
    {
        private med_webb_database db;
        private empleado_services empleado_services;

        public EmpleadoController()
        {
            db = new med_webb_database();
            empleado_services = new empleado_services(db);
        }

        // GET: Pedido
        public ActionResult Index()
        {
            var listaEmpleado = empleado_services.GetAll();
            return View(listaEmpleado);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Empleado empleado)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(empleado);
                }

                var errorMensaje = empleado_services.ValidarAntesCrear(empleado);
                if (string.IsNullOrEmpty(errorMensaje))
                {
                    if (empleado_services.Create(empleado))
                        return RedirectToAction("Index");

                    ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador";
                    return View(empleado);
                }

                ViewBag.ErrorMensaje = errorMensaje;
                return View(empleado);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador" + ex;
                return View(empleado);
            }
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var empleado = empleado_services.BuscarId(id);

            if (empleado == null)
                return RedirectToAction("index");

            return View(empleado);
        }

        [HttpPost]
        public ActionResult Editar(Empleado empleado)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(empleado);
                }

                var errorMenssage = empleado_services.ValidarAntesActualizar(empleado);
                if (string.IsNullOrEmpty(errorMenssage))
                {
                    empleado_services.Update(empleado);
                    return RedirectToAction("index");
                }

                ViewBag.ErrorMensaje = errorMenssage;
                return View(empleado);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador";
                return View(empleado);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            var empleado = empleado_services.BuscarId(id);

            if (empleado == null)
                return RedirectToAction("Index");

            return View(empleado);
        }

        [HttpPost]
        public ActionResult Eliminar(Empleado empleado)
        {
            try
            {
                var errorMensaje = empleado_services.ValidarAntesEliminar(empleado.Id);
                if (string.IsNullOrEmpty(errorMensaje))
                {
                    if (empleado_services.Delete(empleado.Id))
                        return RedirectToAction("Index");

                    ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador";
                    return View(empleado);
                }

                ViewBag.ErrorMensaje = errorMensaje;
                return View(empleado);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador";
                return View(empleado);
            }
        }
    }
}