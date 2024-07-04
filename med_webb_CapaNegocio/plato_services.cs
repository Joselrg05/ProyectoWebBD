using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using med_webb_CapaDato.Modelado;

namespace med_webb_capa_negocio
{
    public class plato_services : crud_services<Platillo>
    {
        private Med_Webb_Database modelo;

        public plato_services(Med_Webb_Database modelo) : base(modelo)
        {
            if (modelo == null)
                this.modelo = new Med_Webb_Database();
            else
                this.modelo = modelo;
        }

        /// <summary>
        /// Validaciones antes de crear un nuevo registro
        /// </summary>
        /// <param name="Plato"></param>
        /// <returns></returns>
        public string ValidarAntesCrear(Platillo objPlato)
        {
            if (modelo.Platillos.Any(x => x.Nombre.Trim().ToLower() == objPlato.Nombre.Trim().ToLower()))
                return "Ya existe un nombre de platillo igual en la entidad Platos";

            return string.Empty;
        }

        /// <summary>
        /// Validaciones antes de actualizar un registro
        /// </summary>
        /// <param name="Plato"></param>
        /// <returns></returns>
        public string ValidarAntesActualizar(Platillo objPlato)
        {
            var platoDb = modelo.Platillos.Find(objPlato.Id);

            if (platoDb == null)
                return "La instancia de platillo a modificar ya no existe en el sistema";

            if (platoDb.Nombre == objPlato.Nombre)
                return string.Empty;

            return ValidarAntesCrear(objPlato);
        }

        public string ValidarAntesEliminar(int id)
        {
            // Busca el Plato en la base de datos por su ID.
            var platoDb = modelo.Platillos.Find(id);

            // Verifica si el plato a eliminar existe en el sistema.
            if (platoDb == null)
                // Si el plato a eliminar no existe, devuelve un mensaje de error.
                return "El plato a eliminar ya no existe en el sistema.";

            // Verifica si el cliente está asociado a otras entidades (en este caso, Resena).
            if (platoDb.DetallePedidos.Count <= 0)
                // Si la validación fue exitosa, devuelve una cadena vacía.
                return string.Empty;
            // Si el cliente está asociado a otras entidades, devuelve un mensaje de error.
            return "El registro no se puede eliminar porque está siendo usado por otras entidades.";
        }

    }
}
