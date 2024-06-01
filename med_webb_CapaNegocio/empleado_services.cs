using med_webb_CapaDato.Modelado
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace med_webb_capa_negocio
{
    public class empleado_services : crud_services<Empleado>
    {
        private med_webb_database db;

        public empleado_services(med_webb_database dbcontext) : base(dbcontext)
        {
            if (dbcontext == null)
                this.db = new med_webb_database();
            else
                this.db = dbcontext;
        }

        public string ValidarAntesCrear(Empleado empleado)
        {
            // Verifica si ya existe un empleado con el mismo id en la base de datos.
            if (db.Empleados.Any(x => x.Id == empleado.Id))
                // Si ya existe un empleado con el mismo id, devuelve un mensaje de error.
                return "Ya existe un empleado con el mismo carnet. Verifique y vuelva a intentar.";

            // Si no existe un empleado con el mismo id, devuelve una cadena vacía indicando que la validación fue exitosa.
            return string.Empty;
        }


        public string ValidarAntesActualizar(Empleado empleado)
        {
            // Busca el empleado en la base de datos por su ID.
            var empleadoDb = db.Empleados.Find(empleado.Id);

            // Verifica si el empleado a modificar ya no existe en el sistema.
            if (empleadoDb == null)
                // Si el empleado a modificar ya no existe, devuelve un mensaje de error.
                return "El empleado a modificar ya no existe en el sistema.";

            // Verifica si el id del empleado a modificar es igual al id original en la base de datos.
            if (empleado.Id == empleadoDb.Id)
                // Si el id del cliente no ha cambiado, no se necesita realizar más validaciones.
                return string.Empty;

            // Si el id del cli ha cambiado, se valida si ya existe otro cliente con el mismo id.
            return ValidarAntesCrear(empleado);
        }

        public string ValidarAntesEliminar(int id)
        {
            // Busca el empleado en la base de datos por su ID.
            var empleadoDb = db.Empleados.Find(id);

            // Verifica si el empleado a eliminar existe en el sistema.
            if (empleadoDb == null)
                // Si el empleado a eliminar no existe, devuelve un mensaje de error.
                return "El empleado a eliminar ya no existe en el sistema.";

            // Verifica si el empleado está asociado a otras entidades (en este caso, Resena).
            if (empleadoDb.Pedidos.Count <= 0)
                // Si la validación fue exitosa, devuelve una cadena vacía.
                return string.Empty;
            // Si el empleado está asociado a otras entidades, devuelve un mensaje de error.
            return "El registro no se puede eliminar porque está siendo usado por otras entidades.";
        }
    }
}
