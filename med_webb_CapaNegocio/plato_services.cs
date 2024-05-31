using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using med_webb_CapaDato.Modelado;

namespace med_webb_capa_negocio
{
    public class plato_services : crud_services<Plato>
    {
        private med_webb_database modelo;

        public plato_services(med_webb_database modelo) : base(modelo)
        {
            if (modelo == null)
                this.modelo = new med_webb_database();
            else
                this.modelo = modelo;
        }

        /// <summary>
        /// Validaciones antes de crear un nuevo registro
        /// </summary>
        /// <param name="Plato"></param>
        /// <returns></returns>
        public string ValidarAntesCrear(Plato objPlato)
        {
            if (modelo.Platos.Any(x => x.nombre_del_plato.Trim().ToLower() == objPlato.nombre_del_plato.Trim().ToLower()))
                return "Ya existe un nombre de platillo igual en la entidad Platos";

            return string.Empty;
        }

        /// <summary>
        /// Validaciones antes de actualizar un registro
        /// </summary>
        /// <param name="Plato"></param>
        /// <returns></returns>
        public string ValidarAntesActualizar(Plato objPlato)
        {
            var platoDb = modelo.Platos.Find(objPlato.Id);

            if (platoDb == null)
                return "La instancia de platillo a modificar ya no existe en el sistema";

            if (platoDb.nombre_del_plato == objPlato.nombre_del_plato)
                return string.Empty;

            return ValidarAntesCrear(objPlato);
        }

        public string ValidarAntesEliminar(int id)
        {
            // Busca el Plato en la base de datos por su ID.
            var platoDb = modelo.Platos.Find(id);

            // Verifica si el plato a eliminar existe en el sistema.
            if (platoDb == null)
                // Si el plato a eliminar no existe, devuelve un mensaje de error.
                return "El plato a eliminar ya no existe en el sistema.";

            // Verifica si el cliente está asociado a otras entidades (en este caso, Resena).
            if (platoDb.Detalle_Pedido_Plato.Count <= 0)
                // Si la validación fue exitosa, devuelve una cadena vacía.
                return string.Empty;
            // Si el cliente está asociado a otras entidades, devuelve un mensaje de error.
            return "El registro no se puede eliminar porque está siendo usado por otras entidades.";
        }

    }
}
