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
    public partial class Factura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Factura()
        {
            this.Detalle_Factura_Platos = new HashSet<Detalle_Factura_Platos>();
        }
    
            [Key]
        public long Id { get; set; }
        public string numero_factura { get; set; }
        public string fecha_emision_factura { get; set; }
        public string modo_de_pago { get; set; }
        public string impuesto_factura { get; set; }
        public string monto_factura { get; set; }
        public long PedidoId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_Factura_Platos> Detalle_Factura_Platos { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
