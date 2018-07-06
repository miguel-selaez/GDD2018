USE GD1C2018;
GO

-- CIERRE TEMPORAL
ALTER TABLE [NPM].[Cierre_Temporal]  DROP CONSTRAINT [FK_Cierre_Temporal_Hotel]
GO


ALTER TABLE [NPM].[Cierre_Temporal]  DROP CONSTRAINT [FK_Cierre_Temporal_Motivo_Cierre] 
GO

-- CLIENTE 
ALTER TABLE [NPM].[Cliente]  DROP CONSTRAINT [FK_Cliente_Persona] 
GO

-- CONSUMO
ALTER TABLE [NPM].[Consumo]  DROP CONSTRAINT [FK_Consumo_Consumible] 
GO

ALTER TABLE [NPM].[Consumo]  DROP CONSTRAINT [FK_Consumo_Estadia] 
GO

ALTER TABLE [NPM].[Consumo]  DROP CONSTRAINT [FK_Consumo_Habitacion_Reservada]
GO

-- DIRECCION
ALTER TABLE [NPM].[Direccion]  DROP CONSTRAINT [FK_Direccion_Pais]
GO

-- ESTADIA
ALTER TABLE [NPM].[Estadia]  DROP CONSTRAINT [FK_Estadia_Reserva]
GO

ALTER TABLE [NPM].[Estadia]  DROP CONSTRAINT [FK_Estadia_Usuario] 
GO

ALTER TABLE [NPM].[Estadia]  DROP CONSTRAINT [FK_Estadia_Usuario1] 
GO

-- FACTURA
ALTER TABLE [NPM].[Factura]  DROP CONSTRAINT [FK_Factura_Cliente]
GO

ALTER TABLE [NPM].[Factura]  DROP CONSTRAINT [FK_Factura_Tipo_Pago] 
GO

-- FUNCIONES X ROL
ALTER TABLE [NPM].[Funciones_x_Rol]  DROP CONSTRAINT [FK_Funciones_x_Rol_Funcion]
GO

ALTER TABLE [NPM].[Funciones_x_Rol]  DROP CONSTRAINT [FK_Funciones_x_Rol_Rol] 
GO


-- HABITACION
ALTER TABLE [NPM].[Habitacion]  DROP CONSTRAINT [FK_Habitacion_Tipo_Habitacion] 
GO

-- HABITACION RESERVADA
ALTER TABLE [NPM].[Habitacion_Reservada]  DROP CONSTRAINT [FK_Habitacion_Reservada_Habitacion] 
GO

ALTER TABLE [NPM].[Habitacion_Reservada]  DROP CONSTRAINT [FK_Habitacion_Reservada_Reserva]
GO

-- HOTEL
ALTER TABLE [NPM].[Hotel]  DROP CONSTRAINT [FK_Hotel_Direccion] 
GO

-- HUESPED X ESTADIA
ALTER TABLE [NPM].[Huesped_x_Estadia]  DROP CONSTRAINT [FK_Huesped_x_Estadia_Cliente] 
GO

ALTER TABLE [NPM].[Huesped_x_Estadia]  DROP CONSTRAINT [FK_Huesped_x_Estadia_Estadia] 
GO

-- ITEM FACTURA
ALTER TABLE [NPM].[Item_Factura]  DROP CONSTRAINT [FK_Item_Factura_Consumo] 
GO

ALTER TABLE [NPM].[Item_Factura]  DROP CONSTRAINT [FK_Item_Factura_Factura]
GO

-- PERSONA
ALTER TABLE [NPM].[Persona]  DROP CONSTRAINT [FK_Persona_Direccion] 
GO

ALTER TABLE [NPM].[Persona]  DROP CONSTRAINT [FK_Persona_Pais] 
GO

ALTER TABLE [NPM].[Persona]  DROP CONSTRAINT [FK_Persona_Tipo_Documento] 
GO

-- REGIMEN X HOTEL
ALTER TABLE [NPM].[Regimen_x_Hotel]  DROP CONSTRAINT [FK_Regimen_x_Hotel_Hotel]
GO

ALTER TABLE [NPM].[Regimen_x_Hotel]  DROP CONSTRAINT [FK_Regimen_x_Hotel_Regimen]
GO

-- RESERVA
ALTER TABLE [NPM].[Reserva]  DROP CONSTRAINT [FK_Reserva_Cliente]
GO

ALTER TABLE [NPM].[Reserva]  DROP CONSTRAINT [FK_Reserva_Estado_Reserva]
GO

ALTER TABLE [NPM].[Reserva]  DROP CONSTRAINT [FK_Reserva_Regimen_x_Hotel] 
GO

-- RESERVA CANCELADA
ALTER TABLE [NPM].[Reserva_Cancelada]  DROP CONSTRAINT [FK_Reserva_Cancelada_Reserva]
GO

ALTER TABLE [NPM].[Reserva_Cancelada]  DROP CONSTRAINT [FK_Reserva_Cancelada_Usuario]
GO

-- RESERVA MODIFICADA
ALTER TABLE [NPM].[Reserva_Modificada]  DROP CONSTRAINT [FK_Reserva_Modificada_Reserva] 
GO

-- ROLES X USUARIO
ALTER TABLE [NPM].[Roles_x_Usuario]  DROP CONSTRAINT [FK_Roles_x_Usuario_Rol]
GO

ALTER TABLE [NPM].[Roles_x_Usuario]  DROP CONSTRAINT [FK_Roles_x_Usuario_Usuario]
GO

-- USUARIO 
ALTER TABLE [NPM].[Usuario]  DROP CONSTRAINT [FK_Usuario_Persona] 
GO

-- USUARIO X HOTEL
ALTER TABLE [NPM].[Usuario_x_Hotel]  DROP CONSTRAINT [FK_Usuario_x_Hotel_Hotel]
GO

ALTER TABLE [NPM].[Usuario_x_Hotel]  DROP CONSTRAINT [FK_Usuario_x_Hotel_Usuario] 
GO

--- TABLAS

TRUNCATE TABLE NPM.Cierre_Temporal
TRUNCATE TABLE NPM.Cliente
TRUNCATE TABLE NPM.Direccion
TRUNCATE TABLE NPM.Consumible
TRUNCATE TABLE NPM.Consumo
TRUNCATE TABLE NPM.Estadia
TRUNCATE TABLE NPM.Estado_Reserva
TRUNCATE TABLE NPM.Factura
TRUNCATE TABLE NPM.Funcion
GO
TRUNCATE TABLE NPM.Funciones_x_Rol
TRUNCATE TABLE NPM.Habitacion
TRUNCATE TABLE NPM.Habitacion_Reservada
TRUNCATE TABLE NPM.Hotel
TRUNCATE TABLE NPM.Huesped_x_Estadia
TRUNCATE TABLE NPM.Item_Factura
TRUNCATE TABLE NPM.Motivo_Cierre
TRUNCATE TABLE NPM.Pais
GO
TRUNCATE TABLE NPM.Persona
TRUNCATE TABLE NPM.Regimen
TRUNCATE TABLE NPM.Regimen_x_Hotel
TRUNCATE TABLE NPM.Reserva
TRUNCATE TABLE NPM.Reserva_Cancelada
TRUNCATE TABLE NPM.Reserva_Modificada
TRUNCATE TABLE NPM.Rol
GO
TRUNCATE TABLE NPM.Roles_x_Usuario
TRUNCATE TABLE NPM.Tipo_Documento
TRUNCATE TABLE NPM.Tipo_Habitacion
TRUNCATE TABLE NPM.Tipo_Pago
TRUNCATE TABLE NPM.Usuario
TRUNCATE TABLE NPM.Usuario_x_Hotel

GO
DROP TABLE NPM.Cierre_Temporal
DROP TABLE NPM.Cliente
DROP TABLE NPM.Direccion
DROP TABLE NPM.Consumible
DROP TABLE NPM.Consumo
DROP TABLE NPM.Estadia
DROP TABLE NPM.Estado_Reserva
DROP TABLE NPM.Factura
DROP TABLE NPM.Funcion
GO
DROP TABLE NPM.Funciones_x_Rol
DROP TABLE NPM.Habitacion
DROP TABLE NPM.Habitacion_Reservada
DROP TABLE NPM.Hotel
DROP TABLE NPM.Huesped_x_Estadia
DROP TABLE NPM.Item_Factura
DROP TABLE NPM.Motivo_Cierre
DROP TABLE NPM.Pais
GO
DROP TABLE NPM.Persona
DROP TABLE NPM.Regimen
DROP TABLE NPM.Regimen_x_Hotel
DROP TABLE NPM.Reserva
DROP TABLE NPM.Reserva_Cancelada
DROP TABLE NPM.Reserva_Modificada
DROP TABLE NPM.Rol
GO
DROP TABLE NPM.Roles_x_Usuario
DROP TABLE NPM.Tipo_Documento
DROP TABLE NPM.Tipo_Habitacion
DROP TABLE NPM.Tipo_Pago
DROP TABLE NPM.Usuario
DROP TABLE NPM.Usuario_x_Hotel

GO