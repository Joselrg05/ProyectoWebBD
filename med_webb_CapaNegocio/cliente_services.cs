using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using med_webb_CapaDato.Modelado;

namespace med_webb_capa_negocio
{
    /// Clase que proporciona servicios específicos para la entidad Cliente.
    /// Hereda funcionalidades de la clase genérica crud_services.
    /// </summary>
    public class cliente_services : crud_services<Cliente>
    {
        // Contexto de la base de datos para interactuar con la entidad Cliente
        private Med_Webb_Database db;

        /// <summary>
        /// Constructor de la clase cliente_services.
        /// Inicializa la instancia con un contexto de la base de datos.
        /// Si no se proporciona un contexto, se crea uno nuevo.
        /// </summary>
        /// <param name="modelo_Entidad">Contexto de la base de datos.</param>
        public cliente_services(Med_Webb_Database modelo_Entidad) : base(modelo_Entidad)
        {
            // Verifica si se proporcionó un contexto de base de datos
            if (modelo_Entidad == null)
                // Si no se proporcionó, se crea un nuevo contexto
                this.db = new Med_Webb_Database();
            else
                // Si se proporcionó, se utiliza el contexto proporcionado
                this.db = modelo_Entidad;
        }

        /// <summary>
        /// Realiza validaciones antes de crear un nuevo registro de cliente.
        /// </summary>
        /// <param name="cliente">El cliente que se desea crear.</param>
        /// <returns>
        /// Un mensaje de error si ya existe un cliente con el mismo id, 
        /// de lo contrario, devuelve una cadena vacía indicando que la validación fue exitosa.
        /// </returns>
        public string ValidarAntesCrear(Cliente cliente)
        {
            // Verifica si ya existe un estudiante con el mismo id en la base de datos.
            if (db.Clientes.Any(x => x.Id== cliente.Id))
                // Si ya existe un estudiante con el mismo id, devuelve un mensaje de error.
                return "Ya existe un cliente con el mismo carnet. Verifique y vuelva a intentar.";

            // Si no existe un cliente con el mismo id, devuelve una cadena vacía indicando que la validación fue exitosa.
            return string.Empty;
        }

        /// <summary>
        /// Realiza validaciones antes de actualizar un registro de cliente.
        /// </summary>
        /// <param name="cliente">El cliente que se desea actualizar.</param>
        /// <returns>
        /// Un mensaje de error si el cliente a modificar ya no existe en el sistema,
        /// o si se intenta actualizar el id a uno que ya existe en otro cliente.
        /// De lo contrario, devuelve una cadena vacía indicando que la validación fue exitosa.
        /// </returns>
        public string ValidarAntesActualizar(Cliente cliente)
        {
            // Busca el cliente en la base de datos por su ID.
            var clienteDb = db.Clientes.Find(cliente.Id);

            // Verifica si el cliente a modificar ya no existe en el sistema.
            if (clienteDb == null)
                // Si el cliente a modificar ya no existe, devuelve un mensaje de error.
                return "El cliente a modificar ya no existe en el sistema.";

            // Verifica si el id del cliente a modificar es igual al id original en la base de datos.
            if (cliente.Id == clienteDb.Id)
                // Si el id del cliente no ha cambiado, no se necesita realizar más validaciones.
                return string.Empty;

            // Si el id del cliente ha cambiado, se valida si ya existe otro cliente con el mismo id.
            return ValidarAntesCrear(cliente);
        }

        /// <summary>
        /// Realiza validaciones antes de eliminar un registro de cliente.
        /// </summary>
        /// <param name="id">El ID del cliente que se desea eliminar.</param>
        /// <returns>
        /// Un mensaje de error si el cliente a eliminar no existe en el sistema o si está asociado a otras entidades,
        /// de lo contrario, devuelve una cadena vacía indicando que la validación fue exitosa.
        /// </returns>
        public string ValidarAntesEliminar(int id)
        {
            // Busca el cliente en la base de datos por su ID.
            var clienteDb = db.Clientes.Find(id);

            // Verifica si el cliente a eliminar existe en el sistema.
            if (clienteDb == null)
                // Si el cliente a eliminar no existe, devuelve un mensaje de error.
                return "El estudiante a eliminar ya no existe en el sistema.";

            // Verifica si el cliente está asociado a otras entidades (en este caso, Resena).
            if (clienteDb.Pedidos.Count <= 0)
                // Si la validación fue exitosa, devuelve una cadena vacía.
                return string.Empty;
            // Si el cliente está asociado a otras entidades, devuelve un mensaje de error.
            return "El registro no se puede eliminar porque está siendo usado por otras entidades.";
        }
    }
}
