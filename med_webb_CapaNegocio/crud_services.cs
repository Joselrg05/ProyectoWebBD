using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace med_webb_capa_negocio
{

    //Define una clase genérica crud_services con un parámetro de tipo 
    //T que se espera que sea una clase.
    public class crud_services <T> where T : class
    {
        /// <summary>
        /// Conexion a la BD
        /// </summary>
        private DbContext db;


       // El constructor de la clase toma un parámetro DbContext 
       //que representa el contexto de la base de datos.Este contexto se 
       //utiliza para interactuar con la base de datos.
        public crud_services(DbContext dbcontext)
        {
            this.db = dbcontext;
        }


        /// <summary>
        /// Funcion para crear una registro de una entidad
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public bool Create(T entidad)
        {
            //Este metodo toma unnn objeto de tipo T
            //como parametro y lo agrega al contextto de la base de datos
            //estableciendo su estado como 'agregado'...
            db.Entry(entidad).State = EntityState.Added;
            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// Funcion para actualizar un registro de una entidad
        /// </summary>
        /// <param name="entidad"></param>
        public void Update(T entidad)
        {
            //Este metodo toma un objeto de tipo 'T'como argumento y actualiza
            //los valores de dicha instancia del objeto en el contexto de la base de
            //datos a 'modificado'...
            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
        }

        /// <summary>
        /// Función para eliminar un registro de una entidad por su ID.
        /// </summary>
        /// <param name="id">El ID del registro que se desea eliminar.</param>
        /// <returns>Devuelve true si se eliminó correctamente el registro, de lo contrario devuelve false.</returns>
        public bool Delete(int id)
        {
            // Busca el registro en la base de datos por su ID
            // utilizando el método Find() del DbSet correspondiente a la entidad T.
            var entidad = db.Set<T>().Find(id);

            // Establece el estado de la entidad encontrada como "Eliminado" en el
            // contexto de la base de datos.
            db.Entry(entidad).State = EntityState.Deleted;

            // Guarda los cambios en la base de datos y devuelve un valor
            // booleano que indica si se eliminó correctamente el registro.
            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// Funcion para listar todos los registros de una entidad
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return db.Set<T>().Where(expression).ToList();
        }

        /// <summary>
        /// Funicon para eliminar un registro de una entidad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T BuscarId(long id)
        {
            var entidad = db.Set<T>().Find(id);
            return entidad;
        }
    }
}
