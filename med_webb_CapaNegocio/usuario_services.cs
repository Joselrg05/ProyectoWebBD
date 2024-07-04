using med_webb_CapaDato.Modelado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace med_webb_capa_negocio
{
    public class usuario_services : crud_services<Usuario>
    {
        private Med_Webb_Database db;

        public usuario_services(Med_Webb_Database dbcontext) : base(dbcontext)
        {
            if (dbcontext == null)
                this.db = new Med_Webb_Database();
            else
                this.db = dbcontext;
        }

        public string ValidarAntesCrear(Usuario Usuario)
        {
            // Verifica si ya existe un Usuario con el mismo id en la base de datos.
            if (db.Usuarios.Any(x => x.Id == Usuario.Id))
                // Si ya existe un Usuario con el mismo id, devuelve un mensaje de error.
                return "Ya existe un Usuario con el mismo carnet. Verifique y vuelva a intentar.";

            // Si no existe un Usuario con el mismo id, devuelve una cadena vacía indicando que la validación fue exitosa.
            return string.Empty;
        }

        public string ValidarAntesActualizar(Usuario Usuario)
        {
            // Busca el Usuario en la base de datos por su ID.
            var UsuarioDb = db.Usuarios.Find(Usuario.Id);

            // Verifica si el Usuario a modificar ya no existe en el sistema.
            if (UsuarioDb == null)
                // Si el Usuario a modificar ya no existe, devuelve un mensaje de error.
                return "El Usuario a modificar ya no existe en el sistema.";

            // Verifica si el id del Usuario a modificar es igual al id original en la base de datos.
            if (Usuario.Id == UsuarioDb.Id)
                // Si el id del cliente no ha cambiado, no se necesita realizar más validaciones.
                return string.Empty;

            // Si el id del cli ha cambiado, se valida si ya existe otro cliente con el mismo id.
            return ValidarAntesCrear(Usuario);
        }

        public string ValidarAntesEliminar(int id)
        {
            // Busca el Usuario en la base de datos por su ID.
            var UsuarioDb = db.Usuarios.Find(id);

            // Verifica si el Usuario a eliminar existe en el sistema.
            if (UsuarioDb == null)
                // Si el Usuario a eliminar no existe, devuelve un mensaje de error.
                return "El Usuario a eliminar ya no existe en el sistema.";

            // Verifica si el Usuario está asociado a otras entidades (en este caso, Resena).
            if (UsuarioDb.Pedidos.Count <= 0)
                // Si la validación fue exitosa, devuelve una cadena vacía.
                return string.Empty;
            // Si el Usuario está asociado a otras entidades, devuelve un mensaje de error.
            return "El registro no se puede eliminar porque está siendo usado por otras entidades.";
        }
    }
}
