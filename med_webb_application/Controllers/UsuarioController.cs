using med_webb_capa_negocio;
using med_webb_CapaDato.Modelado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace med_webb_application.Controllers
{
    public class UsuarioController : Controller
    {
        private Med_Webb_Database db;
        private usuario_services usuario_services;

        public UsuarioController()
        {
            db = new Med_Webb_Database();
            usuario_services = new usuario_services(db);
        }

        // GET: Pedido
        public ActionResult Index()
        {
            var listaEmpleado = usuario_services.GetAll();
            return View(listaEmpleado);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear (Usuario usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(usuario);
                }

                var errorMensaje = usuario_services.ValidarAntesCrear(usuario);
                if (string.IsNullOrEmpty(errorMensaje))
                {
                    if (usuario_services.Create(usuario))
                        return RedirectToAction("Index");

                    ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador";
                    return View(usuario);
                }

                ViewBag.ErrorMensaje = errorMensaje;
                return View(usuario);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador" + ex;
                return View(usuario);
            }
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var usuario = usuario_services.BuscarId(id);

            if (usuario == null)
                return RedirectToAction("index");

            return View(usuario);
        }

        [HttpPost]
        public ActionResult Editar(Usuario usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(usuario);
                }

                var errorMenssage = usuario_services.ValidarAntesActualizar(usuario);
                if (string.IsNullOrEmpty(errorMenssage))
                {
                    usuario_services.Update(usuario);
                    return RedirectToAction("index");
                }

                ViewBag.ErrorMensaje = errorMenssage;
                return View(usuario);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador" + ex;
                return View(usuario);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            var usuario = usuario_services.BuscarId(id);

            if (usuario == null)
                return RedirectToAction("Index");

            return View(usuario);
        }

        [HttpPost]
        public ActionResult Eliminar(Usuario usuario)
        {
            try
            {
                var errorMensaje = usuario_services.ValidarAntesEliminar(usuario.Id);
                if (string.IsNullOrEmpty(errorMensaje))
                {
                    if (usuario_services.Delete(usuario.Id))
                        return RedirectToAction("Index");

                    ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador";
                    return View(usuario);
                }

                ViewBag.ErrorMensaje = errorMensaje;
                return View(usuario);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador" + ex;
                return View(usuario);
            }
        }
    }
}