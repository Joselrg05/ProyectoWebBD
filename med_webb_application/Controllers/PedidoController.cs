using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using med_webb_CapaDato.Modelado;
using System.Web.Mvc;
using med_webb_CapaNegocio;

namespace med_webb_application.Controllers
{
    public class PedidoController : Controller
    {
        private med_webb_database db;
        private pedido_services pedido_Services;

        public PedidoController()
        {
            db = new med_webb_database();
            pedido_Services = new pedido_services(db);
        }

        // GET: Pedido
        public ActionResult Index()
        {
            var listaPedidos = pedido_Services.GetAll();

            return View(listaPedidos);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Pedido pedido)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(pedido);
                }

                var errorMensaje = pedido_Services.ValidarAntesCrear(pedido);
                if (string.IsNullOrEmpty(errorMensaje))
                {
                    if (pedido_Services.Create(pedido))
                        return RedirectToAction("Index");

                    ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador";
                    return View(pedido);
                }

                ViewBag.ErrorMensaje = errorMensaje;
                return View(pedido);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador" + ex;
                return View(pedido);
            }
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var objpedido = pedido_Services.BuscarId(id);
            if (objpedido == null)
                return RedirectToAction("index");

            return View(objpedido);
        }

        [HttpPost]
        public ActionResult Editar(Pedido pedido)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(pedido);
                }

                var errorMenssage = pedido_Services.ValidarAntesActualizar(pedido);
                if (string.IsNullOrEmpty(errorMenssage))
                {
                    pedido_Services.Update(pedido);
                    return RedirectToAction("index");
                }

                ViewBag.ErrorMensaje = errorMenssage;
                return View(pedido);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador";
                return View(pedido);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            var pedido = pedido_Services.BuscarId(id);

            if (pedido == null)
                return RedirectToAction("Index");

            return View(pedido);
        }

        [HttpPost]
        public ActionResult Eliminar(Pedido pedido)
        {
            try
            {
                var errorMensaje = pedido_Services.ValidarAntesEliminar(pedido.Id);
                if (string.IsNullOrEmpty(errorMensaje))
                {
                    if (pedido_Services.Delete(pedido.Id))
                        return RedirectToAction("Index");

                    ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador";
                    return View(pedido);
                }

                ViewBag.ErrorMensaje = errorMensaje;
                return View(pedido);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador";
                return View(pedido);
            }
        }
    }
}