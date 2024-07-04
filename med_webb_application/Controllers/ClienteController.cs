using med_webb_capa_negocio;
using med_webb_CapaDato.Modelado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace med_webb_application.Controllers
{
    public class ClienteController : Controller
    {
        private Med_Webb_Database db;
        private cliente_services cliente_services;

        public ClienteController()
        {
            db = new Med_Webb_Database();
            cliente_services = new cliente_services(db);
        }

        // GET: Pedido
        public ActionResult Index()
        {
            var listacliente = cliente_services.GetAll();
            return View(listacliente);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Cliente cliente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(cliente);
                }

                var errorMensaje = cliente_services.ValidarAntesCrear(cliente);
                if (string.IsNullOrEmpty(errorMensaje))
                {
                    if (cliente_services.Create(cliente))
                        return RedirectToAction("Index");

                    ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador";
                    return View(cliente);
                }

                ViewBag.ErrorMensaje = errorMensaje;
                return View(cliente);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMensaje = "Error servidor, Contactar al administrador" + ex;
                return View(cliente);
            }
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var cliente = cliente_services.BuscarId(id);

            if (cliente == null)
                return RedirectToAction("index");

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Editar(Cliente cliente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(cliente);
                }

                var errorMenssage = cliente_services.ValidarAntesActualizar(cliente);
                if (string.IsNullOrEmpty(errorMenssage))
                {
                    cliente_services.Update(cliente);
                    return RedirectToAction("index");
                }

                ViewBag.ErrorMensaje = errorMenssage;
                return View(cliente);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador" + ex;
                return View(cliente);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            var cliente = cliente_services.BuscarId(id);

            if (cliente == null)
                return RedirectToAction("Index");

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Eliminar(Cliente cliente)
        {
            try
            {
                var errorMensaje = cliente_services.ValidarAntesEliminar(cliente.Id);
                if (string.IsNullOrEmpty(errorMensaje))
                {
                    if (cliente_services.Delete(cliente.Id))
                        return RedirectToAction("Index");

                    ViewBag.ErrorMensaje = "Error servidor, Contactar al administrador";
                    return View(cliente);
                }

                ViewBag.ErrorMensaje = errorMensaje;
                return View(cliente);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMensaje = "Error servidor, Contactar al administrador" + ex;
                return View(cliente);
            }
        }
    }
}