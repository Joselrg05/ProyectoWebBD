﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class med_webb_database : DbContext
    {
        public med_webb_database()
            : base("name=med_webb_database")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Categoria_de_Plato> Categoria_de_Plato { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Detalle_Pedido_Plato> Detalle_Pedido_Plato { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Plato> Platos { get; set; }
        public virtual DbSet<Restaurante> Restaurantes { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}
