using med_webb_capa_negocio;
using med_webb_CapaDato.Modelado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace med_webb_CapaNegocio
{
    public class pedido_services : crud_services<Pedido>
    {
        private Med_Webb_Database modelo;
        
        public pedido_services(Med_Webb_Database modelo) : base(modelo)
        {
            if (modelo == null)
                this.modelo = new Med_Webb_Database();
            else
                this.modelo = modelo;
        }

        /// <summary>
        /// Validaciones antes de crear un nuevo registro
        /// </summary>
        /// <param name="objPedido"></param>
        /// <returns></returns>
        public string ValidarAntesCrear(Pedido objPedido)
        {
            if (modelo.Pedidos.Any(x => x.Id == objPedido.Id))
                return "Ya hay un Id igual en la entidad Pedidos";

            return string.Empty;
        }

        /// <summary>
        /// Validaciones antes de actualizar un registro
        /// </summary>
        /// <param name="objPedido"></param>
        /// <returns></returns>
        public string ValidarAntesActualizar(Pedido objPedido)
        {
            var pedidoDb = modelo.Platillos.Find(objPedido.Id);

            if (pedidoDb == null)
                return "La instancia de pedido a modificar ya no existe en el sistema";

            if (pedidoDb.Id == objPedido.Id)
                return string.Empty;

            return ValidarAntesCrear(objPedido);
        }

        public string ValidarAntesEliminar(int id)
        {
            // Busca el Plato en la base de datos por su ID.
            var pedidoDb = modelo.Pedidos.Find(id);

            // Verifica si el pedido a eliminar existe en el sistema.
            if (pedidoDb == null)
                // Si el pedido a eliminar no existe, devuelve un mensaje de error.
                return "El pedido a eliminar ya no existe en el sistema.";

            // Verifica si el pedido está asociado a otras entidades (en este caso, Detalle del pedido).
            if (pedidoDb.DetallePedidos.Count <= 0)
                // Si la validación fue exitosa, devuelve una cadena vacía.
                return string.Empty;
            // Si el pedido está asociado a otras entidades, devuelve un mensaje de error.
            return "El registro no se puede eliminar porque está siendo usado por otras entidades.";
        }
    }
}
