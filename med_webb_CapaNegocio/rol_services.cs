using med_webb_CapaDato.Modelado;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace med_webb_capa_negocio
{
     public class rol_services : crud_services<Rol>
    {
        private med_webb_database db;

        public rol_services(med_webb_database dbContext) : base(dbContext)
        {
            if (dbContext == null)
                this.db = new med_webb_database();
            else
                this.db = dbContext;
        }

        public string ValidarAntesCrear(Rol rol)
        {
            // Verifica si ya existe un rol con el mismo id en la base de datos.
            if (db.Rols.Any(x => x.Id == rol.Id))
                // Si ya existe un rol con el mismo id, devuelve un mensaje de error.
                return "Ya existe un rol con el mismo ID. Verifique y vuelva a intentar.";

            // Si no existe un Rol con el mismo id, devuelve una cadena vacía indicando que la validación fue exitosa.
            return string.Empty;
        }

        public string ValidarAntesActualizar(Rol rol)
        {
            // Busca el rol en la base de datos por su ID.
            var rolDb = db.Rols.Find(rol.Id);

            // Verifica si el rol a modificar ya no existe en el sistema.
            if (rolDb == null)
                // Si el rol a modificar ya no existe, devuelve un mensaje de error.
                return "El rol a modificar ya no existe en el sistema.";

            // Verifica si el id del Rol a modificar es igual al id original en la base de datos.
            if (rol.Id == rolDb.Id)
                // Si el id del rol no ha cambiado, no se necesita realizar más validaciones.
                return string.Empty;

            // Si el id del rol ha cambiado, se valida si ya existe otro rol con el mismo id.
            return ValidarAntesCrear(rol);
        }

        /// <summary>
        /// Validaciones antes de elimar un registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string ValidarAntesEliminar(int id)
        {
            var rolDb = db.Rols.Find(id);
            db.Entry(rolDb).State = System.Data.Entity.EntityState.Detached;

            if (rolDb == null)
                return "El Rol a modificar ya no existe en el sistema";

            if (rolDb.Usuarios.Count > 0)
                return "El registro no se puede eliminar por que esta siendo usado por otras entidades";

            return string.Empty;
        }
    }
}
