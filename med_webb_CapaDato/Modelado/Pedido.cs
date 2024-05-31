//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace med_webb_CapaDato.Modelado
{
    using System;
    using System.Collections.Generic;
    
    using System.ComponentModel.DataAnnotations;
    public partial class Pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedido()
        {
            this.Detalle_Pedido_Plato = new HashSet<Detalle_Pedido_Plato>();
        }
    
            [Key]
        public long Id { get; set; }
        public string fecha_hora_pedido { get; set; }
        public string estado_del_pedido { get; set; }
        public string cantidad_pedido { get; set; }
        public long EmpleadoId { get; set; }
        public long ClienteId { get; set; }
        public long FacturaId { get; set; }
        public string descripcion_pedido { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_Pedido_Plato> Detalle_Pedido_Plato { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Factura Factura { get; set; }
    }
}
