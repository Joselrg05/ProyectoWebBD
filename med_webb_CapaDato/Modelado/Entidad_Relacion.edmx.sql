
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/30/2024 21:13:26
-- Generated from EDMX file: C:\Users\ABHELL\source\repos\ProyectoWebBD\med_webb_CapaDato\Modelado\Entidad_Relacion.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [med_webb_database];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Categoria_de_PlatoPlato]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Platos] DROP CONSTRAINT [FK_Categoria_de_PlatoPlato];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Clientes] DROP CONSTRAINT [FK_ClienteUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_Detalle_Pedido_PlatoPlato]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Platos] DROP CONSTRAINT [FK_Detalle_Pedido_PlatoPlato];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpleadoPedido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pedidos] DROP CONSTRAINT [FK_EmpleadoPedido];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpleadoUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Empleados] DROP CONSTRAINT [FK_EmpleadoUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_PedidoCliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Clientes] DROP CONSTRAINT [FK_PedidoCliente];
GO
IF OBJECT_ID(N'[dbo].[FK_PedidoDetalle_Pedido_Plato]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Detalle_Pedido_Plato] DROP CONSTRAINT [FK_PedidoDetalle_Pedido_Plato];
GO
IF OBJECT_ID(N'[dbo].[FK_PedidoFactura]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Facturas] DROP CONSTRAINT [FK_PedidoFactura];
GO
IF OBJECT_ID(N'[dbo].[FK_RestauranteCategoria_de_Plato]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Categoria_de_Plato] DROP CONSTRAINT [FK_RestauranteCategoria_de_Plato];
GO
IF OBJECT_ID(N'[dbo].[FK_RestauranteEmpleado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Empleados] DROP CONSTRAINT [FK_RestauranteEmpleado];
GO
IF OBJECT_ID(N'[dbo].[FK_RolUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [FK_RolUsuario];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Categoria_de_Plato]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categoria_de_Plato];
GO
IF OBJECT_ID(N'[dbo].[Clientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clientes];
GO
IF OBJECT_ID(N'[dbo].[Detalle_Pedido_Plato]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Detalle_Pedido_Plato];
GO
IF OBJECT_ID(N'[dbo].[Empleados]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Empleados];
GO
IF OBJECT_ID(N'[dbo].[Facturas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Facturas];
GO
IF OBJECT_ID(N'[dbo].[Pedidos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pedidos];
GO
IF OBJECT_ID(N'[dbo].[Platos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Platos];
GO
IF OBJECT_ID(N'[dbo].[Restaurantes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Restaurantes];
GO
IF OBJECT_ID(N'[dbo].[Rols]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rols];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Categoria_de_Plato'
CREATE TABLE [dbo].[Categoria_de_Plato] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [nombre_de_categoria] nvarchar(max)  NOT NULL,
    [descripcion_categoria] nvarchar(max)  NOT NULL,
    [RestauranteId] bigint  NOT NULL
);
GO

-- Creating table 'Clientes'
CREATE TABLE [dbo].[Clientes] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [nombre_del_cliente] nvarchar(max)  NOT NULL,
    [apellido_de_cliente] nvarchar(max)  NOT NULL,
    [correo_del_cliente] nvarchar(max)  NOT NULL,
    [Usuario_Id] bigint  NOT NULL
);
GO

-- Creating table 'Detalle_Pedido_Plato'
CREATE TABLE [dbo].[Detalle_Pedido_Plato] (
    [Id_detalle_factura_plato] bigint IDENTITY(1,1) NOT NULL,
    [cantidad_detalle] nvarchar(max)  NOT NULL,
    [precio_unitario] nvarchar(max)  NOT NULL,
    [estado_pedido_plato] nvarchar(max)  NOT NULL,
    [PedidoId] bigint  NOT NULL,
    [PlatoId] int  NOT NULL
);
GO

-- Creating table 'Empleados'
CREATE TABLE [dbo].[Empleados] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [nombre_del_empleado] nvarchar(max)  NOT NULL,
    [apellido_del_empleado] nvarchar(max)  NOT NULL,
    [correo_del_empleado] nvarchar(max)  NOT NULL,
    [RestauranteId] bigint  NOT NULL,
    [Usuario_Id] bigint  NOT NULL
);
GO

-- Creating table 'Facturas'
CREATE TABLE [dbo].[Facturas] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [numero_factura] nvarchar(max)  NOT NULL,
    [fecha_emision_factura] nvarchar(max)  NOT NULL,
    [modo_de_pago] nvarchar(max)  NOT NULL,
    [impuesto_factura] nvarchar(max)  NOT NULL,
    [monto_factura] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Pedidos'
CREATE TABLE [dbo].[Pedidos] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [fecha_hora_pedido] nvarchar(max)  NOT NULL,
    [estado_del_pedido] nvarchar(max)  NOT NULL,
    [cantidad_pedido] nvarchar(max)  NOT NULL,
    [EmpleadoId] bigint  NOT NULL,
    [ClienteId] bigint  NOT NULL,
    [FacturaId] bigint  NOT NULL,
    [descripcion_pedido] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Platos'
CREATE TABLE [dbo].[Platos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre_del_plato] nvarchar(max)  NOT NULL,
    [descripcion_del_plato] nvarchar(max)  NOT NULL,
    [precio_del_plato] nvarchar(max)  NOT NULL,
    [Categoria_de_PlatoId] bigint  NOT NULL
);
GO

-- Creating table 'Restaurantes'
CREATE TABLE [dbo].[Restaurantes] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [nombre_restaurante] nvarchar(max)  NOT NULL,
    [contacto_restaurante] nvarchar(max)  NOT NULL,
    [direccion_restaurante] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Rols'
CREATE TABLE [dbo].[Rols] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [nombre_rol] nvarchar(max)  NOT NULL,
    [fecha_rol] datetime  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [nombre_usuario] nvarchar(max)  NOT NULL,
    [password_usuario] nvarchar(max)  NOT NULL,
    [RolId] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Categoria_de_Plato'
ALTER TABLE [dbo].[Categoria_de_Plato]
ADD CONSTRAINT [PK_Categoria_de_Plato]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Clientes'
ALTER TABLE [dbo].[Clientes]
ADD CONSTRAINT [PK_Clientes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id_detalle_factura_plato] in table 'Detalle_Pedido_Plato'
ALTER TABLE [dbo].[Detalle_Pedido_Plato]
ADD CONSTRAINT [PK_Detalle_Pedido_Plato]
    PRIMARY KEY CLUSTERED ([Id_detalle_factura_plato] ASC);
GO

-- Creating primary key on [Id] in table 'Empleados'
ALTER TABLE [dbo].[Empleados]
ADD CONSTRAINT [PK_Empleados]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Facturas'
ALTER TABLE [dbo].[Facturas]
ADD CONSTRAINT [PK_Facturas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pedidos'
ALTER TABLE [dbo].[Pedidos]
ADD CONSTRAINT [PK_Pedidos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Platos'
ALTER TABLE [dbo].[Platos]
ADD CONSTRAINT [PK_Platos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Restaurantes'
ALTER TABLE [dbo].[Restaurantes]
ADD CONSTRAINT [PK_Restaurantes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Rols'
ALTER TABLE [dbo].[Rols]
ADD CONSTRAINT [PK_Rols]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Categoria_de_PlatoId] in table 'Platos'
ALTER TABLE [dbo].[Platos]
ADD CONSTRAINT [FK_Categoria_de_PlatoPlato]
    FOREIGN KEY ([Categoria_de_PlatoId])
    REFERENCES [dbo].[Categoria_de_Plato]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Categoria_de_PlatoPlato'
CREATE INDEX [IX_FK_Categoria_de_PlatoPlato]
ON [dbo].[Platos]
    ([Categoria_de_PlatoId]);
GO

-- Creating foreign key on [RestauranteId] in table 'Categoria_de_Plato'
ALTER TABLE [dbo].[Categoria_de_Plato]
ADD CONSTRAINT [FK_RestauranteCategoria_de_Plato]
    FOREIGN KEY ([RestauranteId])
    REFERENCES [dbo].[Restaurantes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RestauranteCategoria_de_Plato'
CREATE INDEX [IX_FK_RestauranteCategoria_de_Plato]
ON [dbo].[Categoria_de_Plato]
    ([RestauranteId]);
GO

-- Creating foreign key on [Usuario_Id] in table 'Clientes'
ALTER TABLE [dbo].[Clientes]
ADD CONSTRAINT [FK_ClienteUsuario]
    FOREIGN KEY ([Usuario_Id])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteUsuario'
CREATE INDEX [IX_FK_ClienteUsuario]
ON [dbo].[Clientes]
    ([Usuario_Id]);
GO

-- Creating foreign key on [PedidoId] in table 'Detalle_Pedido_Plato'
ALTER TABLE [dbo].[Detalle_Pedido_Plato]
ADD CONSTRAINT [FK_PedidoDetalle_Pedido_Plato]
    FOREIGN KEY ([PedidoId])
    REFERENCES [dbo].[Pedidos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PedidoDetalle_Pedido_Plato'
CREATE INDEX [IX_FK_PedidoDetalle_Pedido_Plato]
ON [dbo].[Detalle_Pedido_Plato]
    ([PedidoId]);
GO

-- Creating foreign key on [EmpleadoId] in table 'Pedidos'
ALTER TABLE [dbo].[Pedidos]
ADD CONSTRAINT [FK_EmpleadoPedido]
    FOREIGN KEY ([EmpleadoId])
    REFERENCES [dbo].[Empleados]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpleadoPedido'
CREATE INDEX [IX_FK_EmpleadoPedido]
ON [dbo].[Pedidos]
    ([EmpleadoId]);
GO

-- Creating foreign key on [Usuario_Id] in table 'Empleados'
ALTER TABLE [dbo].[Empleados]
ADD CONSTRAINT [FK_EmpleadoUsuario]
    FOREIGN KEY ([Usuario_Id])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpleadoUsuario'
CREATE INDEX [IX_FK_EmpleadoUsuario]
ON [dbo].[Empleados]
    ([Usuario_Id]);
GO

-- Creating foreign key on [RestauranteId] in table 'Empleados'
ALTER TABLE [dbo].[Empleados]
ADD CONSTRAINT [FK_RestauranteEmpleado]
    FOREIGN KEY ([RestauranteId])
    REFERENCES [dbo].[Restaurantes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RestauranteEmpleado'
CREATE INDEX [IX_FK_RestauranteEmpleado]
ON [dbo].[Empleados]
    ([RestauranteId]);
GO

-- Creating foreign key on [RolId] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [FK_RolUsuario]
    FOREIGN KEY ([RolId])
    REFERENCES [dbo].[Rols]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RolUsuario'
CREATE INDEX [IX_FK_RolUsuario]
ON [dbo].[Usuarios]
    ([RolId]);
GO

-- Creating foreign key on [ClienteId] in table 'Pedidos'
ALTER TABLE [dbo].[Pedidos]
ADD CONSTRAINT [FK_ClientePedido]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[Clientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientePedido'
CREATE INDEX [IX_FK_ClientePedido]
ON [dbo].[Pedidos]
    ([ClienteId]);
GO

-- Creating foreign key on [PlatoId] in table 'Detalle_Pedido_Plato'
ALTER TABLE [dbo].[Detalle_Pedido_Plato]
ADD CONSTRAINT [FK_PlatoDetalle_Pedido_Plato]
    FOREIGN KEY ([PlatoId])
    REFERENCES [dbo].[Platos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlatoDetalle_Pedido_Plato'
CREATE INDEX [IX_FK_PlatoDetalle_Pedido_Plato]
ON [dbo].[Detalle_Pedido_Plato]
    ([PlatoId]);
GO

-- Creating foreign key on [FacturaId] in table 'Pedidos'
ALTER TABLE [dbo].[Pedidos]
ADD CONSTRAINT [FK_FacturaPedido]
    FOREIGN KEY ([FacturaId])
    REFERENCES [dbo].[Facturas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FacturaPedido'
CREATE INDEX [IX_FK_FacturaPedido]
ON [dbo].[Pedidos]
    ([FacturaId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------