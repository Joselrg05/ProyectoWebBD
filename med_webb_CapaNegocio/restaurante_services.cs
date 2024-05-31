using med_webb_CapaDato.Modelado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace med_webb_capa_negocio
{
    public class restaurante_services : crud_services<Restaurante>
    {
        private med_webb_database db;

        public restaurante_services(med_webb_database dbcontext) : base(dbcontext)
        {
            if (dbcontext == null)
                this.db = new med_webb_database();
            else
                this.db = dbcontext;
        }

        public string ValidarAntesCrear(Restaurante restaurante)
        {
            // Verifica si ya existe un restaurante con el mismo id en la base de datos.
            if (db.Restaurantes.Any(x => x.Id == restaurante.Id))
                // Si ya existe un Restaurante con el mismo id, devuelve un mensaje de error.
                return "Ya existe un restaurante con el mismo ID. Verifique y vuelva a intentar.";

            // Si no existe un Restaurante con el mismo id, devuelve una cadena vacía indicando que la validación fue exitosa.
            return string.Empty;
        }


        public string ValidarAntesActualizar(Restaurante restaurante)
        {
            // Busca el restaurante en la base de datos por su ID.
            var restauranteDb = db.Restaurantes.Find(restaurante.Id);

            // Verifica si el restaurante a modificar ya no existe en el sistema.
            if (restauranteDb == null)
                // Si el restaurante a modificar ya no existe, devuelve un mensaje de error.
                return "El Restaurante a modificar ya no existe en el sistema.";

            // Verifica si el id del Restaurante a modificar es igual al id original en la base de datos.
            if (restaurante.Id == restauranteDb.Id)
                // Si el id del restaurante no ha cambiado, no se necesita realizar más validaciones.
                return string.Empty;

            // Si el id del restaurante ha cambiado, se valida si ya existe otro cliente con el mismo id.
            return ValidarAntesCrear(restaurante);
        }

        public string ValidarAntesEliminar(int id)
        {
            // Busca el Restaurante en la base de datos por su ID.
            var restauranteDb = db.Restaurantes.Find(id);

            // Verifica si el restaurante a eliminar existe en el sistema.
            if (restauranteDb == null)
                // Si el restaurante a eliminar no existe, devuelve un mensaje de error.
                return "El restaurante a eliminar ya no existe en el sistema.";

            // Verifica si el restaurante está asociado a otras entidades (en este caso, Empleado).
            if (restauranteDb.Empleados.Count <= 0)
                // Si la validación fue exitosa, devuelve una cadena vacía.
                return string.Empty;
            // Si el Restaurante está asociado a otras entidades, devuelve un mensaje de error.
            return "El registro no se puede eliminar porque está siendo usado por otras entidades.";
        }
    }
}
